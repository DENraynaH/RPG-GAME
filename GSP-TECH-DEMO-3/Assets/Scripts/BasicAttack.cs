using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    private GameUnit targetedUnit;
    [SerializeField] private float attackRange;
    [SerializeField] private float baseDamage;

    public void Attack()
    {
         if (GameManager.Instance.selectedUnit == null) { return; }
         if (GameManager.Instance.selectedUnit == GetComponent<GameUnit>()) {  return; }

        targetedUnit = GameManager.Instance.selectedUnit;
        float distanceBetween = GetDistance(transform.position, targetedUnit.transform.position);
        if (distanceBetween <= attackRange)
        {
            DamageSystem.Instance.Damage(GetComponent<GameUnit>(), targetedUnit, baseDamage);
            PlayerController.Instance.playerAnimator.isAttacking = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }





















    public float GetDistance(Vector2 currentPosition, Vector2 targetPosition) 
    { return Vector2.Distance(currentPosition, targetPosition); }


}
