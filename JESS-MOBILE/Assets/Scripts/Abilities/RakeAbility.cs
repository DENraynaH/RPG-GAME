using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Rake", fileName = "Rake Ability")]
public class RakeAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        Debug.Log("Rake");
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Rake, targetUnit, playerUnit);
        yield return null;
    }
}
