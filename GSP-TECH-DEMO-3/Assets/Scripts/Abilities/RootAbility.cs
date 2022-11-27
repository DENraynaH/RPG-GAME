using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Abilities/Root", fileName = "Wrath Ability")]
public class RootAbility : Ability
{
    public Projectile wrathProjectile;
    public float wrathSpeed;
    public GameObject effect;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        AbilityTools.DefaultAbilitySetup();
        yield return new WaitForSeconds(castingTime);

        if (GameManager.Instance.movedDuringCast) { yield break; }

        playerUnit.resourceSystem.currentResource -= resourceCost;
        Instantiate(effect, targetUnit.transform.position, Quaternion.identity);
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Root, targetUnit, playerUnit);
    }
}
