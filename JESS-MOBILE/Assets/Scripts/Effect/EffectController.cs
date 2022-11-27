using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectController : MonoBehaviour
{
    public static EffectController Instance;
    public enum EffectType { Moonfire, Rake, Moonfire2}

    private void Awake() => Instance = this;

    public void ApplyEffect(EffectType effectType, GameUnit damageReciver, GameUnit damageGiver)
    {
        Effect effect = GetEffect(effectType);

        foreach (Effect currentEffect in damageReciver.resourceSystem.currentEffects)
        {
            Debug.Log(currentEffect);
            if (currentEffect.GetType() == effect.GetType()) 
            {
                currentEffect._currentDuration = 0;
                currentEffect.Reset();
                return;
            }
        }

        effect.effectStart += EffectStart;
        effect.effectEnd += EffectEnd;

        StartCoroutine(effect.Apply(damageReciver, damageGiver));
    }

    void EffectStart(Effect effect, GameUnit gameUnit)
    {
        ResourceSystem resourceSystem = gameUnit.resourceSystem;
        resourceSystem.currentEffects.Add(effect);
        UIManager.Instance.UpdateEffectUI(gameUnit.resourceSystem.currentEffects);
    }

    void EffectEnd(Effect effect, GameUnit gameUnit)
    {
        ResourceSystem resourceSystem = gameUnit.resourceSystem;
        resourceSystem.currentEffects.Remove(effect);
        UIManager.Instance.UpdateEffectUI(gameUnit.resourceSystem.currentEffects);

        effect.effectEnd -= EffectEnd;
        effect.effectStart -= EffectStart;
    }

    private Effect GetEffect(EffectType effectType)
    {
        switch (effectType)
        {
            case EffectType.Moonfire:
                return new EffectMoonfire(10, Color.red, 5, 2);
            case EffectType.Rake:
                return new EffectRake(10, Color.yellow, 5, 2);
            case EffectType.Moonfire2:
                break;
                //return avaliableEffects[2];
        }
        return null;
    }
}
