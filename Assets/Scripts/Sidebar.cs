using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonExtension
{
    // button, itemIndex, callback
    public static void AddEventListener<T>(this Button button, T itemIndex, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate ()
        {
            OnClick(itemIndex);
        });
    }
}

namespace GoogleARCore.Examples.ObjectManipulation
{
    public class Sidebar : Manipulator
    {
        [SerializeField] string[] elementName = null;

        public Text Textfield;
        public string atom;

        public GameObject HydrogenPrefab;
        public GameObject OxygenPrefab;
        public GameObject SodiumPrefab;
        public GameObject ChloridePrefab;
        public GameObject HydroxidePrefab;
        public GameObject HCLPrefab;
        public GameObject SodiumHydroxidePrefab;

        public GameObject ManipulatorPrefab;

        public Camera FirstPersonCamera;

        public void SetSelectedText(string text)
        {
            Textfield.text = text;
        }

        // Start is called before the first frame update
        void Start()
        {
            GameObject button = transform.GetChild(0).gameObject; // get the first button
            GameObject g; // keep track of new created items
            // parent = the same object that holds the script (transform) or (this.transform)
            for (int i = 0; i < elementName.Length; i++)
            {
                g = Instantiate(button, transform);
                g.transform.GetChild(0).GetComponent<Text>().text = elementName[i];

                //g.GetComponent<Button>().onClick.AddListener(delegate ()
                //{
                //    ItemClicked(i);
                //});

                g.GetComponent<Button>().AddEventListener(i, ItemClicked);
            }

            Destroy(button); // destroy the button template
        }

        void SetAtomText(string molecule)
        {
            atom = molecule;
        }

        void ItemClicked(int itemIndex)
        {
            Debug.Log("-----Item " + itemIndex + " clicked-----");
            Debug.Log("Element Name: " + elementName[itemIndex]);
            SetAtomText(elementName[itemIndex]);
            SetSelectedText(elementName[itemIndex] + " is selected");
        }

        // Update is called once per frame
        void Update()
        {

        }

        GameObject CreateAtomPrefab(string molecule, TrackableHit hit) 
        {
            Debug.Log("create atom prefab: " + molecule);

            switch(molecule)
            {
                case AtomConstants.HYDROGEN:
                    
                    return Instantiate(HydrogenPrefab, hit.Pose.position, hit.Pose.rotation);
                default:
                    return null;
            }
        }

        protected override bool CanStartManipulationForGesture(TapGesture gesture)
        {
            if (gesture.TargetObject == null)
            {
                return true;
            }

            return false;
        }

        protected override void OnEndManipulation(TapGesture gesture)
        {
            if (gesture.WasCancelled)
            {
                return;
            }

            // If gesture is targeting an existing object we are done.
            if (gesture.TargetObject != null)
            {
                return;
            }

            // Raycast against the location the player touched to search for planes.
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;

            if (Frame.Raycast(
                gesture.StartPosition.x, gesture.StartPosition.y, raycastFilter, out hit))
            {
                // Use hit pose and camera pose to check if hittest is from the
                // back of the plane, if it is, no need to create the anchor.
                if ((hit.Trackable is DetectedPlane) &&
                    Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
                        hit.Pose.rotation * Vector3.up) < 0)
                {
                    Debug.Log("Hit at back of the current DetectedPlane");
                }
                else
                {

                    if (!String.IsNullOrEmpty(atom))
                    {
                        Debug.Log("Creating: " + atom);

                        var atomPrefab = CreateAtomPrefab(atom, hit);

                        if (atomPrefab == null)
                        {
                            Debug.Log("Error: cannot create: " + atom);
                            return;
                        }

                        var manipulator =
                                Instantiate(ManipulatorPrefab, hit.Pose.position, hit.Pose.rotation);
                        atomPrefab.transform.parent = manipulator.transform;

                        var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                        manipulator.transform.parent = anchor.transform;
                        manipulator.GetComponent<Manipulator>().Select();
                    }
                    else 
                    {
                        Debug.Log("No atom selected");
                    }
                }
            }
        }
    }
}