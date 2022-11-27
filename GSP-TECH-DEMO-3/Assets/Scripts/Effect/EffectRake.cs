using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRake : Effect
{
    [SerializeField] private float _tickRate;

    public override IEnumerator Apply(GameUnit EffectReciver, GameUnit EffectGiver)
    {
        _currentDuration = 0;
        _tickRate = 2;

        effectStart?.Invoke(this, EffectReciver);
        while (_currentDuration < _effectDuration)
        {
            _currentDuration += Time.deltaTime;
            if (_currentDuration >= _tickRate)
            {
                DamageSystem.Instance.Damage(EffectGiver, EffectReciver, _effectValue);
                _tickRate += 2;
                Debug.Log($"Current End Duration: {_effectDuration} Current Duration: {_currentDuration}");
            }
            yield return null;
        }
        effectEnd?.Invoke(this, EffectReciver);
    }

    public override void Reset() { _tickRate = 2; }

    public EffectRake(float effectDuration, Color effectColor, float effectValue, float tickDuration, Sprite sprite)
    {
        _effectDuration = effectDuration;
        _effectColor = effectColor;
        _effectValue = effectValue;
        _tickRate = tickDuration;
        _effectSprite = sprite;
    }

}
