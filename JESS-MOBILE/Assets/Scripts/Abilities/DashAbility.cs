using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash", fileName = "Dash Ability")]
public class DashAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        Debug.Log("Dash");
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Rake, targetUnit, playerUnit);
        yield return null;
    }
}
