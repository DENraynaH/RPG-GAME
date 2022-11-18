using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Wrath", fileName = "Wrath Ability")]
public class WrathAbility : Ability
{
    public Projectile wrathProjectile;
    public float wrathSpeed;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Moonfire, targetUnit);

        yield return new WaitForSeconds(castingTime);
        Vector2 spawnPosition = playerUnit.transform.position;
        Projectile projectile = Instantiate(wrathProjectile, spawnPosition, Quaternion.identity);
        projectile.Activate(wrathSpeed, abilityValue, targetUnit);
    }
}
