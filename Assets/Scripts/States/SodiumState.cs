using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodiumState : AtomState
{
    public MonoBehaviour sodiumHydroxide;

    public MonoBehaviour sodiumChloride;
    protected override MonoBehaviour MakeStateChange(Collider other)
    {           
        MonoBehaviour atom;
        switch(other.tag)
        {
            case AtomConstants.HYDROXIDE:
                atom = Instantiate(sodiumHydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            case AtomConstants.CHLORIDE:
                atom = Instantiate(sodiumChloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            default:
                return null;
        }
    }
}