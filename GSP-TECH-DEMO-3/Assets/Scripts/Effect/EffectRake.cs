using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRake : Effect
{
    [SerializeField] private float _tickDuration;

    public override IEnumerator Apply(GameUnit gameUnit)
    {
        _currentDuration = _effectDuration;
        float currentDuration = 0;

        effectStart?.Invoke(this, gameUnit);
        while (currentDuration < _currentDuration)
        {
            yield return new WaitForSeconds(_tickDuration);
            DamageSystem.Instance.Heal(gameUnit.gameObject, _effectValue);
            currentDuration += _tickDuration;

            Debug.Log($"Current End Duration: {_currentDuration} Current Duration: {currentDuration}");
        }
        effectEnd?.Invoke(this, gameUnit);
    }
    public EffectRake(float effectDuration, Color effectColor, float effectValue, float tickDuration)
    {
        _effectDuration = effectDuration;
        _effectColor = effectColor;
        _effectValue = effectValue;
        _tickDuration = tickDuration;
    }

}
