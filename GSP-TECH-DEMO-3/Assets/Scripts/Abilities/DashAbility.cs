using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Dash", fileName = "Dash Ability")]
public class DashAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        if (playerUnit.isStealthed == false) { yield break; }
        playerUnit.resourceSystem.currentResource -= resourceCost;
        while (playerUnit.transform.position != targetUnit.transform.position)
        {
            playerUnit.transform.position = Vector2.MoveTowards(playerUnit.transform.position, targetUnit.transform.position, abilityValue * Time.deltaTime);
            yield return null;
        }
    }
}
