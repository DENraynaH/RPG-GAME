using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Abilities/Ghost", fileName = "Wrath Ability")]
public class GhostAbility : Ability
{
    public Projectile wrathProjectile;
    public float wrathSpeed;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        AbilityTools.DefaultAbilitySetup();
        yield return new WaitForSeconds(castingTime);
        if (GameManager.Instance.movedDuringCast) { yield break; }

        playerUnit.resourceSystem.currentResource -= resourceCost;
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Cloak, playerUnit, playerUnit);
    }
}
