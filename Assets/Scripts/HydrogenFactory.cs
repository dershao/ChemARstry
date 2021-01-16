using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydrogenFactory : IAtomFactory
{
    public Hydrogen prefab;
    public override Atom GetInstance() {

        return Instantiate(prefab);
    }
}