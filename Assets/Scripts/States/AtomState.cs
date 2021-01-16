using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AtomState : MonoBehaviour
{

    // boolean if this atom is being selected
    protected bool selected;

    protected abstract bool MakeStateChange(Collider other); 

    protected bool ChangeStates(Collider other)
    {

        if (selected) {
            
            return MakeStateChange(other);
        }

        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (ChangeStates(other))
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnMouseDown()
    {
        // Debug.Log("on moused down");
        selected = true;
    }

    void OnMouseUp() 
    {
        // Debug.Log("on mouse up");
        selected = false;
    }
}

