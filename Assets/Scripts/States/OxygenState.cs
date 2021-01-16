using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenState : AtomState
{
    public MonoBehaviour hydroxide;

    protected override bool MakeStateChange(Collider other)
    {           
        switch(other.tag)
        {
            case AtomConstants.HYDROGEN:
                Instantiate(hydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            default:
                return false;
        }
    }
}
