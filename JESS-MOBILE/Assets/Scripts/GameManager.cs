using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameUnit hoveredUnit;
    public GameUnit selectedUnit;

    public Action moveDurationCast;
    public bool movedDuringCast { get; set; }

    private void Awake() => Instance = this;
    private void Start() => moveDurationCast += StopCurrentAbility;

    private void Update()
    {
        MouseControls();
    }

    public void MouseControls()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UIManager uiManager = UIManager.Instance;

            if (uiManager == null) { uiManager = UIManager.Instance; }
            if (hoveredUnit == null) { return; }
            selectedUnit = hoveredUnit;

            uiManager.UpdateEffectUI(selectedUnit.resourceSystem.currentEffects);
            uiManager.TargetPanelState(true);
            uiManager.UpdateUI(selectedUnit);
        }
    }

    public void StopCurrentAbility()
    {
        UIManager uiManager = UIManager.Instance;

        uiManager.SetCastingBar(false);
        movedDuringCast = true;
        AbilityTools.currentlyCasting = false;
    }

    public void Debuger()
    {
        Debug.Log("you bugger");
    }
}
