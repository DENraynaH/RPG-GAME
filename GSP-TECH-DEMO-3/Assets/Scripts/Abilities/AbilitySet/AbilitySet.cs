using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilitySet/Ability Set", fileName = "AbilitySet")]
public class AbilitySet : ScriptableObject
{
    public Set abilityOne;
    public Set abilityTwo;
    public Set abilityThree;
    public Set abilityFour;
}

[Serializable]
public class Set
{
    public Ability ability;
    public Sprite sprite;
}
