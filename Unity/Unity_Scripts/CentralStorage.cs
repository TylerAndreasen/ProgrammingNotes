using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralStorage
{
    
    private List<Trait> allTraits = new List<Trait>();

    public void PushTrait(Trait input)
    {
        allTraits.Add(input);
    }
    public int TraitCount() { return allTraits.Count; }
    public Trait[] GetTraits()
    {
        return allTraits.ToArray();
    }
}
