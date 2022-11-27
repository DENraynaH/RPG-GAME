using System.Collections;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public AbilitySet[] _abilitySets = new AbilitySet[4];
    public Ability[] _equipedAbilities = new Ability[4];
    public float[] _lastUsed = new float[4];

    private float _equippedSet;

    private void Start() => SwitchAbilitySet(0);

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
        if (_equipedAbilities[abilityIndex].castType == Ability.CastType.EnemyOnly && targetUnit == null) { return; }
        if (_equipedAbilities[abilityIndex].castType == Ability.CastType.Both && targetUnit == null) { return; }

        if (AbilityTools.currentlyCasting) { return; } 
        if (!AbilityTools.allowedToCast) { return; }
        if (!AbilityTools.HasEnoughMana(playerUnit, _equipedAbilities[abilityIndex])) { return; }

        if (IsCooldown(_equipedAbilities[abilityIndex].abilityCooldown, _lastUsed[abilityIndex])) { return; }
        _lastUsed[abilityIndex] = Time.time;


        PlayerController.Instance.playerAnimator.isCasting = true;
        PlayerController.Instance.playerAnimator.castDuration = _equipedAbilities[abilityIndex].castingTime;
        StartCoroutine(DoGlobalCooldown(abilityIndex));
        StartCoroutine(AbilityTools.DoCooldown(abilityIndex, _equipedAbilities[abilityIndex].abilityCooldown)); 
        StartCoroutine(AbilityTools.DoCasting(_equipedAbilities[abilityIndex].castingTime));

        if (_equipedAbilities[abilityIndex].castType == Ability.CastType.SelfOnly)
        {
            StartCoroutine(_equipedAbilities[abilityIndex].Activate(playerUnit, playerUnit));
        }
        else
        {
            Debug.Log("test");
            StartCoroutine(_equipedAbilities[abilityIndex].Activate(playerUnit, targetUnit));
        }
    }

    public void ToggleAbilitySet()
    {
        if (_equippedSet == 0) 
        { 
            SwitchAbilitySet(1); 
            PlayerController.Instance.playerAnimator.isCat = true;
            UIManager.Instance.playerResource.color = Color.red;
        }
        else 
        {  
            SwitchAbilitySet(0); 
            PlayerController.Instance.playerAnimator.isCat = false;
            UIManager.Instance.playerResource.color = Color.blue;
        }
    }

    public void SwitchAbilitySet(int abilitySet)
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
        _equippedSet = abilitySet;
    }

    public IEnumerator DoGlobalCooldown(int abilitySlotExclude)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i != abilitySlotExclude) { StartCoroutine(AbilityTools.DoCooldown(i, 1.5f)); }
        }
        AbilityTools.allowedToCast = false;
        yield return new WaitForSeconds(1.5f);
        AbilityTools.allowedToCast = true;
    }

    public void AbilityButton(int ability)
    {
        GameUnit playerUnit = PlayerController.Instance.GetComponent<GameUnit>();
        GameUnit targetUnit = GameManager.Instance.selectedUnit;

        switch (ability)
        {
            case 0:
                ActivateAbility(0, playerUnit, targetUnit);
                break;
            case 1:
                ActivateAbility(1, playerUnit, targetUnit);
                break;
            case 2:
                ActivateAbility(2, playerUnit, targetUnit);
                break;
            case 3:
                ActivateAbility(3, playerUnit, targetUnit);
                break;
        }
    }
 }
