using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenState : AtomState
{
    public MonoBehaviour hydroxide;

    protected override MonoBehaviour MakeStateChange(Collider other)
    {           
        MonoBehaviour atom;
        switch(other.tag)
        {
            case AtomConstants.HYDROGEN:
                atom = Instantiate(hydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            default:
                return null;
        }
    }
}
