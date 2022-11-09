using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamager : DamageSystem
{
    public float autoAttackRange;

    public void AutoAttack()
    {
        if (GameManager.Instance.selectedUnit == null) { return; }
        float distanceFromTarget = GetDistanceFromTarget(GameManager.Instance.selectedUnit.gameObject.transform.position);
        if (distanceFromTarget > autoAttackRange) { return; }

     
    }





}
