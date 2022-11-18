using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityTools
{
    private static float _castingStay = 0.25f;

    public static IEnumerator DoCasting(float castDuration)
    {
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
}
