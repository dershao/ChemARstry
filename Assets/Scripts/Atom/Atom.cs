using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    protected float maxHeight;
    protected float minHeight;

    // direction of the current element
    protected bool up;

    // name of this atom
    protected string atomName;

    // Start is called before the first frame update
    protected void Start()
    {
        maxHeight = transform.position.y + 0.6f;
        minHeight = transform.position.y - 0.6f;

        up = false;
    }

    protected void Update()
    {
        oscillate(maxHeight, minHeight);        
    }

    protected void oscillate(float maxHeight, float minHeight) {
        
        if (transform.position.y > maxHeight || transform.position.y < minHeight) {
            changeDirection();
        } 

        if (this.up) {
            transform.position += Vector3.up * 0.01f;
        } else {
            transform.position -= Vector3.up * 0.01f;
        }
    }

    protected void changeDirection() {

        up = !up;
    }


    void OnMouseDrag() 
    {
        // move atom around with mouse
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
        
        maxHeight = transform.position.y + 1;
        minHeight = transform.position.y - 1;
    }
}