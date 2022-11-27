using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectTools
{
    public static IEnumerator DoCooldown(Effect effect, float effectDuration, float startPercentage)
    {
        while (effect._currentDuration < effectDuration)
        {
            if (effect._effectObjectUI != null) { UIManager.Instance.SetEffectCooldown(effect, effect._currentDuration / effectDuration); }
            yield return null;
        }
        if (effect._effectObjectUI != null) { UIManager.Instance.SetEffectCooldown(effect, 0); }
    }
}
