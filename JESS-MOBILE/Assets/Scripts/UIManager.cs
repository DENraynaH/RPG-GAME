using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image[] abilitySprites = new Image[4];

    public GameObject uiCanvas;

    public Image playerPanel;
    public Image targetPanel;

    public Image targetResource;
    public Image targetHealth;

    public Image playerResource;
    public Image playerHealth;

    public TextMeshProUGUI targetText;

    public Image castingBar;

    public Image[] abilityCooldowns = new Image[4];

    [Header("EFFECTS")]
    public GameObject defaultEffect;

    public float positionOffset;
    public RectTransform effectPositionTarget;
    public RectTransform effectPositionPlayer;

    public List<GameObject> targetEffects = new List<GameObject>();
    public List<GameObject> playerEffects = new List<GameObject>();

    public static UIManager Instance;

    private float _currentOffset;

    private void Start()
    {
        Instance = this;

        playerPanel.gameObject.SetActive(true);
        targetPanel.gameObject.SetActive(false);
    }

    public void UpdateCastingValue(float fillAmount)
    {
        castingBar.fillAmount = fillAmount;
    }

    public void SetCastingBar(bool value)
    {
        GameObject castingBarObject = castingBar.gameObject.transform.parent.gameObject;

        if (value) { castingBarObject.SetActive(true); }
        else { castingBarObject.SetActive(false);  }
    }

    public void SetCooldown(int cooldownSlot, float fillAmount)
    {
        abilityCooldowns[cooldownSlot].fillAmount = fillAmount;
    }

    public void SetEffectCooldown(Effect effect, float fillAmount)
    {
        Image cooldownImage = effect._effectObjectUI.transform.GetChild(1).GetComponent<Image>();
        cooldownImage.fillAmount = fillAmount;
    }

    public void UpdateEffectUI(List<Effect> currentEffects)
    {
        ClearTargetUI();
        targetEffects.Clear();

        _currentOffset = -positionOffset;

        for (int i = 0; i < currentEffects.Count; i++)
        {
            _currentOffset += positionOffset;

            GameObject effectUI = Instantiate(defaultEffect, uiCanvas.transform);
            effectUI.transform.position = new Vector2(effectUI.transform.position.x + _currentOffset, effectUI.transform.position.y);
            effectUI.transform.SetParent(targetPanel.gameObject.transform);
            effectUI.transform.GetChild(0).GetComponent<Image>().color = currentEffects[i]._effectColor;
            currentEffects[i]._effectObjectUI = effectUI;


            //float durationLeft = currentEffects[i]._effectDuration - currentEffects[i]._currentDuration;
            //Debug.Log(durationLeft);
            StartCoroutine(EffectTools.DoCooldown(currentEffects[i], currentEffects[i]._effectDuration, currentEffects[i]._currentDuration));

            targetEffects.Add(effectUI);
        }
    }

    public void ClearTargetUI()
    {
        foreach (GameObject item in targetEffects)
        { Destroy(item); }
    }

    public void ClearPlayerUI()
    { foreach (GameObject item in playerEffects) { Destroy(item); } }

    public void SetAbilitySprites(Sprite spriteOne, Sprite spriteTwo, Sprite spriteThree, Sprite spriteFour)
    {
        abilitySprites[0].sprite = spriteOne;
        abilitySprites[1].sprite = spriteTwo;
        abilitySprites[2].sprite = spriteThree;
        abilitySprites[3].sprite = spriteFour;
    }

    public void UpdateUI(GameUnit gameUnit)
    {
        ResourceSystem resourceSystem = PlayerController.Instance.resourceSystem;

        playerHealth.fillAmount = resourceSystem.GetHealthDecimal();
        playerResource.fillAmount = resourceSystem.GetResourceDecimal();

        targetText.text = gameUnit.unitStats.unitName;
        targetHealth.fillAmount = gameUnit.resourceSystem.GetHealthDecimal();
        targetResource.fillAmount = gameUnit.resourceSystem.GetResourceDecimal();
    }

    public void TargetPanelState(bool targetPanelState)
    {
        if (targetPanelState) { targetPanel.gameObject.SetActive(true); }
        else { targetPanel.gameObject.SetActive(false); }
    }

}
