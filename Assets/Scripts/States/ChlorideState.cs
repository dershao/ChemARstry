using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChlorideState : AtomState
{
    public MonoBehaviour hcl;

    public MonoBehaviour sodiumChloride;

    protected override bool MakeStateChange(Collider other)
    {           
        switch(other.tag)
        {
            case AtomConstants.HYDROGEN:
                Instantiate(hcl, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            case AtomConstants.SODIUM:
                Instantiate(sodiumChloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            default:
                return false;
        }
    }
}