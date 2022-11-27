using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectController : MonoBehaviour
{
    public Sprite moonfireSprite;
    public Sprite rakeSprite;
    public Sprite rootsSprite;
    public Sprite ghostSprite;

    public static EffectController Instance;
    public enum EffectType { Moonfire, Rake, Cloak, Root}

    private void Awake() => Instance = this;

    public void ApplyEffect(EffectType effectType, GameUnit damageReciver, GameUnit damageGiver)
    {
        Effect effect = GetEffect(effectType);

        foreach (Effect currentEffect in damageReciver.resourceSystem.currentEffects)
        {
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
        ResourceSystem eResourceSystem = gameUnit.resourceSystem;
        eResourceSystem.currentEffects.Add(effect);
        UIManager.Instance.UpdateEffectUI(eResourceSystem.currentEffects);
        UIManager.Instance.UpdatePlayerEffectUI(PlayerController.Instance.resourceSystem.currentEffects);
    }

    void EffectEnd(Effect effect, GameUnit gameUnit)
    {
        ResourceSystem eResourceSystem = gameUnit.resourceSystem;
        eResourceSystem.currentEffects.Remove(effect);
        UIManager.Instance.UpdateEffectUI(eResourceSystem.currentEffects);
        UIManager.Instance.UpdatePlayerEffectUI(PlayerController.Instance.resourceSystem.currentEffects);

        effect.effectEnd -= EffectEnd;
        effect.effectStart -= EffectStart;
    }

    private Effect GetEffect(EffectType effectType)
    {
        switch (effectType)
        {
            case EffectType.Moonfire:
                return new EffectMoonfire(10, Color.red, 5, 2, moonfireSprite);
            case EffectType.Rake:
                return new EffectRake(10, Color.yellow, 5, 2, rakeSprite);
            case EffectType.Cloak:
                return new EffectCloak(30, Color.red, 0, ghostSprite);
            case EffectType.Root:
                return new EffectRoots(10, Color.yellow, 5, 1, rootsSprite);
        }
        return null;
    }
}
