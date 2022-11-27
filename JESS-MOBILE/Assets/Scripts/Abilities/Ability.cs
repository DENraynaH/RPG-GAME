using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    [field:Header("Ability Stats")]
    [field:SerializeField] public float castingTime { get; private set; }
    [field:SerializeField] public float abilityCooldown { get; private set; }
    [field:SerializeField] public Sprite abilitySprite { get; private set; }
    [field:SerializeField] public int abilityValue { get; private set; }
    [field: SerializeField] public float resourceCost { get; private set; }

    protected enum AbilityType { afterCast, duringCast }
    protected AbilityType abilityType = AbilityType.afterCast;

    public abstract IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit);
}
