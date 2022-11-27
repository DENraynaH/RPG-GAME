using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Moonfire", fileName = "Moonfire Ability")]
public class MoonfireAbility : Ability
{
    [SerializeField] private GameObject moonfireVisuals;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        AbilityTools.DefaultAbilitySetup();

        yield return new WaitForSeconds(castingTime);

        playerUnit.resourceSystem.currentResource -= resourceCost;
        Instantiate(moonfireVisuals, targetUnit.transform.position, Quaternion.identity);
        EffectController.Instance.ApplyEffect(EffectController.EffectType.Moonfire, targetUnit, playerUnit);
        yield return null;
    }
}
