using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceSystem : MonoBehaviour
{
    [Header("Health")]
    public float maximumHealth;
    public float currentHealth;
    public float spawnHealth;

    [Header("Resource")]
    public float maximumResource;
    public float currentResource;
    public float spawnResource;

    public UnityEvent onDeath;

    private void Start()
    {
        currentHealth = spawnHealth;
        currentResource = spawnResource;
    }

    public void ReduceHealth(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth - damageAmount < 0) { currentHealth = 0; }
        UIManager.Instance.playerHealth.fillAmount = currentHealth / maximumHealth;
        if (currentHealth == 0) { onDeath.Invoke(); } 
    }

    public void ReduceResource(int resourceAmount)
    {
        currentResource -= resourceAmount;

        if (currentResource - resourceAmount < 0) { currentResource = 0; }
        UIManager.Instance.playerHealth.fillAmount = currentHealth / maximumHealth;
    }

    public float GetHealthDecimal() { return currentHealth / maximumHealth; }
    public float GetResourceDecimal() { return currentResource / maximumResource; }

}
