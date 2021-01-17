using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChlorideState : AtomState
{
    public MonoBehaviour hcl;

    public MonoBehaviour sodiumChloride;

    protected override MonoBehaviour MakeStateChange(Collider other)
    {         
        MonoBehaviour atom;  
        switch(other.tag)
        {

            case AtomConstants.HYDROGEN:
                atom = Instantiate(hcl, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            case AtomConstants.SODIUM:
                atom = Instantiate(sodiumChloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            default:
                return null;
        }
    }
}