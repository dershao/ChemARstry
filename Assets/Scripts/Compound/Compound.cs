using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore.Examples.ObjectManipulation;
using GoogleARCore.Examples.ObjectManipulationInternal;

public class Compound : Manipulator
{
    // Start is called before the first frame update
    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {
        this.transform.Rotate(new Vector3(0f, 75f, 0f) * Time.deltaTime);   
    }
}
