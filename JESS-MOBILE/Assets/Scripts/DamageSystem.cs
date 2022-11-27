using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public static DamageSystem Instance;
    public GameObject damageIndicator;

    private void Awake() => Instance = this;

    public void Damage(GameUnit damageDealer, GameUnit damageTaker, float baseDamage)
    {
        if (damageTaker.TryGetComponent(out ResourceSystem resourceSystem)) 
        {
            float actualDamage = baseDamage;
            float randomValue = Random.value;

            if (randomValue < damageDealer.unitStats.criticalRate) { actualDamage *= damageDealer.unitStats.criticalDamage; }
            resourceSystem.ReduceHealth(actualDamage);

            float directionOne = Random.Range(0, 2) * 2 - 1;
            float directionTwo = Random.Range(0, 2) * 2 - 1;
            Vector2 randomDirection = new Vector2(directionOne / 2.8f, directionTwo / 2.8f);
            GameObject damagerObject = Instantiate(damageIndicator, (Vector2)damageTaker.transform.position + randomDirection, Quaternion.identity);
            TextMeshProUGUI text = damagerObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            text.text = actualDamage.ToString();
            text.color = Color.red;
        }
    }

    public void CircleDamage(Collider2D collision, int damageAmount, int damageSize, LayerMask damageLayers)
    {

    }

    public void Heal(GameUnit healDealer, GameUnit healTaker, float baseHeal)
    {
        if (healTaker.TryGetComponent(out ResourceSystem resourceSystem)) 
        {
            float actualHeal = baseHeal;
            float randomValue = Random.value;

            if (randomValue < healDealer.unitStats.criticalRate) { actualHeal *= healDealer.unitStats.criticalDamage; }
            resourceSystem.IncreaseHealth(actualHeal);

            float directionOne = Random.Range(0, 2) * 2 - 1;
            float directionTwo = Random.Range(0, 2) * 2 - 1;
            Vector2 randomDirection = new Vector2(directionOne / 2.8f, directionTwo / 2.8f);
            GameObject damagerObject = Instantiate(damageIndicator, (Vector2)healTaker.transform.position + randomDirection, Quaternion.identity);
            TextMeshProUGUI text = damagerObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

            text.text = actualHeal.ToString();
            text.color = Color.green;
        }
    }

    //public float GetDistance(Vector2 currentPosition, Vector2 targetPosition) 
    //{ return Vector2.Distance(currentPosition, targetPosition); }

}
