using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : Atom
{

    new void Start()
    {
        // same as super in java
        base.Start();
        
        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);

        name = "Oxygen";
    }
}
