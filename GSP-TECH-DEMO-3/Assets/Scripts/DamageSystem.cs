using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    protected int damageAmount;
    protected LayerMask damageLayers;

    protected void DoDamage(Collider2D collision)
    {
        if (!((damageLayers.value & (1 << collision.gameObject.layer)) > 0)) { return; }
        if (collision.TryGetComponent(out ResourceSystem resourceSystem)) { resourceSystem.ReduceHealth(damageAmount); }
    }
    protected float GetDistanceFromTarget(Vector2 target) { return Vector2.Distance(transform.position, target); }

}
