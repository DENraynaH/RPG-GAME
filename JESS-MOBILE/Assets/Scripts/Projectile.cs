using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D projectileBody;
    public LayerMask targetLayer;
    private int _projectileDamage;

    private void Awake()
    {
        projectileBody = GetComponent<Rigidbody2D>();
    }

    public void Activate(float projectileSpeed, int projectileDamage, GameUnit target)
    {
        _projectileDamage = projectileDamage;

        Vector2 targetPosition = (target.transform.position - transform.position).normalized * projectileSpeed;
        projectileBody.velocity = new Vector2(targetPosition.x, targetPosition.y);
        Destroy(gameObject, 3);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((targetLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            //DamageSystem.Instance.DamageOverTime(collision, 5, 2, 5);
            DamageSystem.Instance.Damage(PlayerController.Instance.gameUnit, collision.gameObject.GetComponent<GameUnit>(), _projectileDamage);
            Destroy(gameObject);
        }
    }
}
