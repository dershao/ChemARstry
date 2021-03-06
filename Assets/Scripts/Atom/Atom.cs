using System.Collections;
using System.Collections.Generic;
using GoogleARCore;
using GoogleARCore.Examples.ObjectManipulation;
using GoogleARCore.Examples.ObjectManipulationInternal;
using UnityEngine;
using UnityEngine.UI;

public class Atom : Manipulator
{
    protected float maxHeight;
    protected float minHeight;

    // direction of the current element
    protected bool up;

    // name of this atom
    protected string atomName;

    protected void Start()
    {
        maxHeight = transform.position.y + 0.1f;
        minHeight = transform.position.y - 0.1f;

        up = false;
    }

    protected void oscillate(float maxHeight, float minHeight)
    {

        if (transform.position.y > maxHeight || transform.position.y < minHeight)
        {
            changeDirection();
        }

        if (this.up)
        {
            transform.position += Vector3.up * 0.01f;
        }
        else
        {
            transform.position -= Vector3.up * 0.01f;
        }
    }

    protected void changeDirection()
    {

        up = !up;
    }


    protected void Update()
    {
        oscillate(maxHeight, minHeight);
    }

    void OnMouseDrag()
    {
        // move atom around with mouse
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

        maxHeight = transform.position.y + 0.1f;
        minHeight = transform.position.y - 0.1f;

    }
}