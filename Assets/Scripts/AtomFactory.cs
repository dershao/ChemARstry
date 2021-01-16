using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomFactory : MonoBehaviour
{
    private static Dictionary<string, IAtomFactory> atoms;
    public static Dictionary<string, IAtomFactory> GetInstance() 
    {
        if (atoms == null) 
        {
            atoms = new Dictionary<string, IAtomFactory>();

            atoms.Add(AtomConstants.HYDROGEN, new HydrogenFactory());

            return atoms;
        } else {
            
            return atoms;
        }
    }
}