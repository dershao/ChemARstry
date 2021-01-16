using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAtomFactory : MonoBehaviour
{
    public abstract Atom GetInstance();
}