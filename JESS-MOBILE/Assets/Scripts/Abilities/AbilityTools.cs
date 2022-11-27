using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityTools
{
    public static float _castingStay = 0.25f;
    public static bool currentlyCasting = false;
    public static bool allowedToCast = true;

    public static IEnumerator DoCasting(float castDuration)
    {
        currentlyCasting = true;
        UIManager.Instance.SetCastingBar(true);
        float currentDuration = 0f;
        while (currentDuration < castDuration)
        {
            currentDuration += Time.deltaTime;
            UIManager.Instance.UpdateCastingValue(currentDuration / castDuration);
            yield return null;
        }
        yield return new WaitForSeconds(_castingStay);
        UIManager.Instance.SetCastingBar(false);
        currentlyCasting = false;
    }

    public static IEnumerator DoCooldown(int abilitySlot, float abilityCooldown)
    {
        float currentDuration = 0f;
        while (currentDuration < abilityCooldown)
        {
            currentDuration += Time.deltaTime;
            UIManager.Instance.SetCooldown(abilitySlot, currentDuration / abilityCooldown);
            yield return null;
        }
        UIManager.Instance.SetCooldown(abilitySlot, 0);
    }

    public static bool HasEnoughMana(GameUnit gameUnit, Ability ability)
    {
        if (gameUnit.resourceSystem.currentResource >= ability.resourceCost) { return true; }
        return false;
    }

    //Anything that needs to run before an ability starts
    public static void DefaultAbilitySetup()
    {
        GameManager.Instance.movedDuringCast = false;
    }
}
