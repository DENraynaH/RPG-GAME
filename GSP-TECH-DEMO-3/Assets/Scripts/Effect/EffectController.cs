using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectController : MonoBehaviour
{
    public static EffectController Instance;

    //public List<Effect> avaliableEffects = new List<Effect>();
    public enum EffectType { Moonfire, Rake, Moonfire2}

    private void Awake() => Instance = this;

    private void Start()
    {
        //EffectMoonfire effectMoonfire = new EffectMoonfire(10, Color.red, 5, 2);
        //EffectRake effectRake = new EffectRake(10, Color.red, 5, 2);

        //avaliableEffects.Add(effectMoonfire);
        //avaliableEffects.Add(effectRake);
    }

    public void ApplyEffect(EffectType effectType, GameUnit gameUnit)
    {
        Effect effect = GetEffect(effectType);
        if (gameUnit.resourceSystem.currentEffects.Contains(effect)) // CHECK FOR CONTAIN TYPE INSTEAD OF CONTAIN INSTANCE
        {
            effect._currentDuration += effect._effectDuration;
            return;
        }

        effect.effectStart += EffectStart;
        effect.effectEnd += EffectEnd;

        StartCoroutine(effect.Apply(gameUnit));
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
