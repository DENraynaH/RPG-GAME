using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class AbilityController : MonoBehaviour
{
    public AbilitySet[] _abilitySets = new AbilitySet[4];

    public Ability[] _equipedAbilities = new Ability[4];
    public float[] _lastUsed = new float[4];

    private void Update()
    {
        HandleAbilityControls();
        if (Input.GetKeyDown(KeyCode.F9)) { SwitchAbilitySet(0); }
        if (Input.GetKeyDown(KeyCode.F8)) { SwitchAbilitySet(1); }
    }

    private void HandleAbilityControls()
   {
        GameUnit playerUnit = PlayerController.Instance.GetComponent<GameUnit>();
        GameUnit targetUnit = GameManager.Instance.selectedUnit;
        if (targetUnit == null || playerUnit == null) { return; }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { ActivateAbility(0, playerUnit, targetUnit); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { ActivateAbility(1, playerUnit, targetUnit); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { ActivateAbility(2, playerUnit, targetUnit); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { ActivateAbility(3, playerUnit, targetUnit); }
    }

    private bool IsCooldown(float abilityCooldown, float lastUsed)
    {
        if (lastUsed == 0.0f) { return false; }
        if (Time.time < lastUsed + abilityCooldown) { return true; }
        else { return false; }
    }

    private void ActivateAbility(int abilityIndex, GameUnit playerUnit, GameUnit targetUnit) 
    {
        if (IsCooldown(_equipedAbilities[abilityIndex].abilityCooldown, _lastUsed[abilityIndex])) { return; }
        _lastUsed[abilityIndex] = Time.time;

        StartCoroutine(AbilityTools.DoCooldown(abilityIndex, _equipedAbilities[abilityIndex].abilityCooldown));
        StartCoroutine(AbilityTools.DoCasting(_equipedAbilities[abilityIndex].castingTime));
        StartCoroutine(_equipedAbilities[abilityIndex].Activate(playerUnit, targetUnit));
    }

    private void SwitchAbilitySet(int abilitySet)
    {
        Set setOne = _abilitySets[abilitySet].abilityOne;
        Set setTwo = _abilitySets[abilitySet].abilityTwo;
        Set setThree = _abilitySets[abilitySet].abilityThree;
        Set setFour = _abilitySets[abilitySet].abilityFour;

        _equipedAbilities[0] = setOne.ability;
        _equipedAbilities[1] = setTwo.ability;
        _equipedAbilities[2] = setThree.ability;
        _equipedAbilities[3] = setFour.ability;

        UIManager.Instance.SetAbilitySprites(setOne.sprite, setTwo.sprite, setThree.sprite, setFour.sprite);
    }
}
