using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability :  ScriptableObject 
{
    protected float castingTime;
    protected float abilityCooldown;
    protected Sprite abilitySprite;

    protected enum AbilityType { afterCast, duringCast }
    protected AbilityType abilityType = AbilityType.afterCast;

    public abstract IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit);

}
