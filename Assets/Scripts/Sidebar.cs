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

public class Sidebar : MonoBehaviour
{
    [SerializeField] string[] elementName = null;

    public Text Textfield;

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

    void ItemClicked(int itemIndex)
    {
        Debug.Log("-----Item " + itemIndex + " clicked-----");
        Debug.Log("Element Name: " + elementName[itemIndex]);
        SetSelectedText(elementName[itemIndex] + " is selected");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
