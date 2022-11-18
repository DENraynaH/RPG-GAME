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

    public float resourceRegeneration;
    public float healthRegeneration;

    public float resourceDuration;
    public float healthDuration;

    public List<Effect> currentEffects = new List<Effect>();
    public UnityEvent onDeath;

    private float resourceTimer;
    private float healthTimer;

    private void Start()
    {
        currentHealth = spawnHealth;
        currentResource = spawnResource;
    }

    private void Update()
    {
        //ResourceRegeneration();
    }

    public void ReduceHealth(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0) { currentHealth = 0; }
        if (currentHealth == 0) { onDeath.Invoke(); OnDeath(); } 
        GameManager.Instance.UpdateUI();
    }

    public void ReduceResource(float resourceAmount)
    {
        currentResource -= resourceAmount;

        if (currentResource - resourceAmount < 0) { currentResource = 0; }
        GameManager.Instance.UpdateUI();
    }

    public void IncreaseResource(float resourceAmount)
    {
        currentResource += resourceAmount;
        if (resourceAmount > maximumResource) { currentResource = maximumResource; }
        GameManager.Instance.UpdateUI();
    }

    public void IncreaseHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maximumHealth) { currentHealth = maximumHealth; }
        GameManager.Instance.UpdateUI();
    }

    public float GetHealthDecimal() { return currentHealth / maximumHealth; }
    public float GetResourceDecimal() { return currentResource / maximumResource; }
    public void OnDeath()
    {
        //Default OnDeath Things
    }

    private void ResourceRegeneration()
    {
        resourceTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;

        if (resourceTimer >= resourceDuration)
        {
            IncreaseResource(resourceRegeneration);
            resourceRegeneration = 0;
        }
        if (healthTimer >= healthDuration)
        {
            IncreaseHealth(healthDuration);
            healthTimer = 0;
        }
    }

}
