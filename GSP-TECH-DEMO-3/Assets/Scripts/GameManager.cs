using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameUnit hoveredUnit;
    public GameUnit selectedUnit;

    private UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
        Instance = this;
    }

    private void Update()
    {
        MouseControls();
    }

    public void MouseControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (uiManager == null) { uiManager = UIManager.Instance; }
            if (hoveredUnit == null) { return; }
            selectedUnit = hoveredUnit;

            uiManager.UpdateEffectUI(selectedUnit.resourceSystem.currentEffects);

            TargetPanelState(true);
            UpdateUI();
           
        }
    }

    public void DebugControls()
    {
        if (Input.GetKeyDown(KeyCode.F1)) { }
        if (Input.GetKeyDown(KeyCode.F2)) { }
        if (Input.GetKeyDown(KeyCode.F3)) { }
        if (Input.GetKeyDown(KeyCode.F4)) { }
        if (Input.GetKeyDown(KeyCode.F5)) { }
        if (Input.GetKeyDown(KeyCode.F6)) { }
        if (Input.GetKeyDown(KeyCode.F7)) { }
        if (Input.GetKeyDown(KeyCode.F8)) { }
        if (Input.GetKeyDown(KeyCode.F9)) { }
    }

    public void UpdateUI()
    {
        ResourceSystem resourceSystem = PlayerController.Instance.GetComponent<ResourceSystem>();

        //Player
        uiManager.playerHealth.fillAmount = resourceSystem.GetHealthDecimal(); 
        uiManager.playerResource.fillAmount = resourceSystem.GetResourceDecimal();

        //Target
        uiManager.targetText.text = selectedUnit.unitName;
        uiManager.targetHealth.fillAmount = selectedUnit.resourceSystem.GetHealthDecimal();
        uiManager.targetResource.fillAmount = selectedUnit.resourceSystem.GetResourceDecimal();
    }

    public void TargetPanelState(bool targetPanelState)
    {
        if (targetPanelState) { uiManager.targetPanel.gameObject.SetActive(true); }
        else { uiManager.targetPanel.gameObject.SetActive(false); }
    }

}
