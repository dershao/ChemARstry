using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenState : AtomState
{
    public MonoBehaviour hydroxide;
    public MonoBehaviour hydrochloride;

    public MonoBehaviour h2o;

    protected override MonoBehaviour MakeStateChange(Collider other)
    {           
        MonoBehaviour atom;
        switch(other.tag)
        {
            case AtomConstants.OXYGEN:
                atom = Instantiate(hydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            case AtomConstants.HYDROXIDE:
                atom = Instantiate(h2o, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            case AtomConstants.CHLORIDE:
                atom = Instantiate(hydrochloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return atom;
            default:
                return null;
        }
    }
}