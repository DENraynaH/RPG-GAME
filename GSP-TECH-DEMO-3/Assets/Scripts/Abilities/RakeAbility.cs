using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Rake", fileName = "Rake Ability")]
public class RakeAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        DamageSystem.Instance.Damage(playerUnit, targetUnit, abilityValue);
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Rake, targetUnit, playerUnit);
        targetUnit.comboPoints++;

        playerUnit.resourceSystem.currentResource -= resourceCost;
        yield return null;
    }
}
