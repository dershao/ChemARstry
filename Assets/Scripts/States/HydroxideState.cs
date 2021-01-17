using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydroxideState : AtomState
{
    public MonoBehaviour h2o;

    protected override MonoBehaviour MakeStateChange(Collider other)
    {           
        MonoBehaviour atom;
        switch(other.tag)
        {
            case AtomConstants.HYDROGEN:
                atom = Instantiate(h2o, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            default:
                return null;
        }
    }
}
