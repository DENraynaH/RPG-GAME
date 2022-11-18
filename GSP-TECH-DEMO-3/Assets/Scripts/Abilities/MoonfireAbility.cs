using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Moonfire", fileName = "Moonfire Ability")]
public class MoonfireAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        Debug.Log("Moonfire");
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Rake, targetUnit);
        //EffectController.Instance.ApplyEffect(EffectController.EffectType.Moonfire2, targetUnit);
        yield return null;
    }
}
