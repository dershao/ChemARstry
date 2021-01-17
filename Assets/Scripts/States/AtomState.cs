using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore.Examples.ObjectManipulation;
using GoogleARCore.Examples.ObjectManipulationInternal;
using GoogleARCore;

public abstract class AtomState : Manipulator
{

    // boolean if this atom is being selected
    protected bool selected;

    public GameObject ManipulatorPrefab;

    protected abstract MonoBehaviour MakeStateChange(Collider other); 

    protected MonoBehaviour ChangeStates(Collider other)
    {

        TrackableHit hit;
        TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon;
        if (selected) {

            MonoBehaviour createdAtom = MakeStateChange(other);


            if (Frame.Raycast(
                createdAtom.transform.position.x, createdAtom.transform.position.y, raycastFilter, out hit))
            {

            
                var manipulator = Instantiate(ManipulatorPrefab, hit.Pose.position, hit.Pose.rotation);
                createdAtom.transform.parent = manipulator.transform;

                var anchor = hit.Trackable.CreateAnchor(hit.Pose);

                manipulator.transform.parent = anchor.transform;
                manipulator.GetComponent<Manipulator>().Select();
            }

            return createdAtom;
        }

        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");
        if (ChangeStates(other) != null)
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("on moused down");
        selected = true;
    }

    void OnMouseUp() 
    {
        Debug.Log("on mouse up");
        selected = false;
    }
}

