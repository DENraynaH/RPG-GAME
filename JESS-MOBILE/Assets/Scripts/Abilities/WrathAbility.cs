using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Abilities/Wrath", fileName = "Wrath Ability")]
public class WrathAbility : Ability
{
    public Projectile wrathProjectile;
    public float wrathSpeed;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        AbilityTools.DefaultAbilitySetup();
        

        EffectController.Instance.ApplyEffect(EffectController.EffectType.Moonfire, targetUnit, playerUnit);
        yield return new WaitForSeconds(castingTime);

        if (GameManager.Instance.movedDuringCast) { yield break; }

        playerUnit.resourceSystem.currentResource -= resourceCost;
        Vector2 spawnPosition = playerUnit.transform.position;
        Projectile projectile = Instantiate(wrathProjectile, spawnPosition, Quaternion.identity);
        projectile.Activate(wrathSpeed, abilityValue, targetUnit);
    }
}
