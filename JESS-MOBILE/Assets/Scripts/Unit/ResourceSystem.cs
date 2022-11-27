using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class ResourceSystem : MonoBehaviour
{
    private GameUnit gameUnit;

    [Header("Health")]
    public float maximumHealth;
    public float currentHealth;
    public float spawnHealth;

    [Header("Resource")]
    public float maximumResource;
    public float currentResource;
    public float spawnResource;

    public List<Effect> currentEffects = new List<Effect>();
    public UnityEvent onDeath;

    private float resourceTimer;
    private float healthTimer;

    private void Start()
    {
        currentHealth = spawnHealth;
        currentResource = spawnResource;
        gameUnit = GetComponent<GameUnit>();
    }

    private void Update()
    {
        ResourceRegeneration();
    }

    public void ReduceHealth(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth < 0) { currentHealth = 0; }
        if (currentHealth == 0) { onDeath.Invoke(); OnDeath(); }
        if (GameManager.Instance.selectedUnit == gameUnit) { UIManager.Instance.UpdateUI(gameUnit); }
    }

    public void ReduceResource(float resourceAmount)
    {
        currentResource -= resourceAmount;

        if (currentResource - resourceAmount < 0) { currentResource = 0; }
        if (GameManager.Instance.selectedUnit == gameUnit) { UIManager.Instance.UpdateUI(gameUnit); }
    }

    public void IncreaseResource(float resourceAmount)
    {
        currentResource += resourceAmount;
        if (resourceAmount > maximumResource) { currentResource = maximumResource; }
        if (GameManager.Instance.selectedUnit == gameUnit) { UIManager.Instance.UpdateUI(gameUnit); }
    }

    public void IncreaseHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > maximumHealth) { currentHealth = maximumHealth; }
        if (GameManager.Instance.selectedUnit == gameUnit) { UIManager.Instance.UpdateUI(gameUnit); }
    }

    public float GetHealthDecimal() { return currentHealth / maximumHealth; }
    public float GetResourceDecimal() { return currentResource / maximumResource; }
    public void OnDeath()
    {
        if (GameManager.Instance.selectedUnit == gameUnit)
        {
            UIManager.Instance.TargetPanelState(false);
        }
    }

    private void ResourceRegeneration()
    {
        resourceTimer += Time.deltaTime;
        healthTimer += Time.deltaTime;

        if (resourceTimer >= gameUnit.unitStats.resourceRate)
        {
            IncreaseResource(gameUnit.unitStats.resourceRegeneration);
            resourceTimer = 0;
        }
        if (healthTimer >= gameUnit.unitStats.healthRate)
        {
            IncreaseHealth(gameUnit.unitStats.healthRegeneration);
            healthTimer = 0;
        }
    }

}
