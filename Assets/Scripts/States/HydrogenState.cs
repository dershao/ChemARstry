using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenState : AtomState
{
    public MonoBehaviour hydroxide;
    public MonoBehaviour hydrochloride;

    public MonoBehaviour h2o;

    protected override bool MakeStateChange(Collider other)
    {           
        switch(other.tag)
        {
            case AtomConstants.OXYGEN:
                Instantiate(hydroxide, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            case AtomConstants.HYDROXIDE:
                Instantiate(h2o, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            case AtomConstants.CHLORIDE:
                Instantiate(hydrochloride, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                return true;
            default:
                return false;
        }
    }
}