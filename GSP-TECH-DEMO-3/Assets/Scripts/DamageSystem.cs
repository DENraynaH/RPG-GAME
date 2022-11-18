using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem Instance; 
    private void Awake() => Instance = this;

    public void Damage(GameObject collision, float damageAmount)
    {
        if (collision.TryGetComponent(out ResourceSystem resourceSystem)) { resourceSystem.ReduceHealth(damageAmount); }
    }

    public void CircleDamage(Collider2D collision, int damageAmount, int damageSize, LayerMask damageLayers)
    {

    }

    public void Heal(GameObject collision, float healAmount)
    {
        if (collision.TryGetComponent(out ResourceSystem resourceSystem)) { resourceSystem.IncreaseHealth(healAmount); }
    }




    //public float GetDistance(Vector2 currentPosition, Vector2 targetPosition) 
    //{ return Vector2.Distance(currentPosition, targetPosition); }

}
