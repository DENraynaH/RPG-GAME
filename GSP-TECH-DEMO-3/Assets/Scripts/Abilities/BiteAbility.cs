using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bite", fileName = "Bite Ability")]
public class BiteAbility : Ability
{
    public override IEnumerator Activate(GameUnit playerUnit, GameUnit targetUnit)
    {
        DamageSystem damageSystem = DamageSystem.Instance;

        if (targetUnit.comboPoints == 1) { damageSystem.Damage(playerUnit, targetUnit, Random.Range(40, 75)); targetUnit.comboPoints = 0; }
        if (targetUnit.comboPoints == 2) { damageSystem.Damage(playerUnit, targetUnit, Random.Range(89, 112)); targetUnit.comboPoints = 0; }
        if (targetUnit.comboPoints == 3) { damageSystem.Damage(playerUnit, targetUnit, Random.Range(135, 167)); targetUnit.comboPoints = 0; }
        if (targetUnit.comboPoints == 4) { damageSystem.Damage(playerUnit, targetUnit, Random.Range(184, 209)); targetUnit.comboPoints = 0; }
        if (targetUnit.comboPoints >= 5) { damageSystem.Damage(playerUnit, targetUnit, Random.Range(224, 257)); targetUnit.comboPoints = 0; }

        playerUnit.resourceSystem.currentResource -= resourceCost;
        yield return null;
    }
}
