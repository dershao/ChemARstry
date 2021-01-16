using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroxideState : AtomState
{
    public MonoBehaviour h2o;

    protected override bool MakeStateChange(Collider other)
    {           
        switch(other.tag)
        {
            case AtomConstants.HYDROGEN:
                Instantiate(h2o, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            default:
                return false;
        }
    }
}
