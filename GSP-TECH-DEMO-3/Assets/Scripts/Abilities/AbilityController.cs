using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability[] equipedAbilities = new Ability[4];
    private void Update()
    {
        HandleAbilityControls();
    }

    private void HandleAbilityControls()
   {
        GameUnit playerUnit = PlayerController.Instance.GetComponent<GameUnit>();
        GameUnit targetUnit = GameManager.Instance.selectedUnit;

        if (targetUnit == null || playerUnit == null) { return; }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { StartCoroutine(equipedAbilities[0].Activate(playerUnit, targetUnit)); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {  }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {  }
        if (Input.GetKeyDown(KeyCode.Alpha4)) {  }
    }

}
