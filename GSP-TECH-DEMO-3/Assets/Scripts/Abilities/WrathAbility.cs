using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Wrath", fileName = "Wrath Ability")]
public class WrathAbility : Ability
{
    public Projectile wrathProjectile;
    public float wrathSpeed;
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        Vector2 spawnPosition = playerUnit.transform.position;

        yield return new WaitForSeconds(castingTime);
        Projectile projectile = Instantiate(wrathProjectile, spawnPosition, Quaternion.identity);
        projectile.Activate(wrathSpeed, targetUnit);
    }
}
