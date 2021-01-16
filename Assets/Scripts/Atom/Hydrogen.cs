using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen : Atom
{
    // public MonoBehaviour hydrogen;

    new void Start()
    {
        // same as super in java
        base.Start();

        var renderer = GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.blue);

        name = "Hydrogen";
    }
}
