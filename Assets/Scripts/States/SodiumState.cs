using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodiumState : AtomState
{
    public MonoBehaviour sodiumHydroxide;

    public MonoBehaviour sodiumChloride;
    protected override bool MakeStateChange(Collider other)
    {           
        switch(other.tag)
        {
            case AtomConstants.HYDROXIDE:
                Instantiate(sodiumHydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            case AtomConstants.CHLORIDE:
                Instantiate(sodiumChloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            default:
                return false;
        }
    }
}