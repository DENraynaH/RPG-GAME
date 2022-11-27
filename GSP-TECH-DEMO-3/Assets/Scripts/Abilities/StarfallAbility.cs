using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Starfall", fileName = "Moonfire Ability")]
public class StarfallAbility : Ability
{
    [SerializeField] private GameObject starfallVisuals;

    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        AbilityTools.DefaultAbilitySetup();

        yield return new WaitForSeconds(castingTime);

        playerUnit.resourceSystem.currentResource -= resourceCost;

        for (int i = 0; i < 20; i++)
        {
            Vector2 lightningPositon = new Vector2(targetUnit.transform.position.x + Random.Range(-2f, 2f), targetUnit.transform.position.y + Random.Range(-2f, 2f));

            yield return new WaitForSeconds(0.2f);
            Instantiate(starfallVisuals, lightningPositon, Quaternion.identity);
            DamageSystem.Instance.Damage(playerUnit, targetUnit, 5);
        }
        yield return null;
    }
}