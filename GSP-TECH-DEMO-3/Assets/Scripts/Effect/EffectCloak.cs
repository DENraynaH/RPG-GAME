using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EffectCloak : Effect
{

    public override IEnumerator Apply(GameUnit EffectReciver, GameUnit EffectGiver)
    {
        Debug.Log("cloak effect");
        _currentDuration = 0;
        PlayerMovement playerMovement = EffectGiver.GetComponent<PlayerMovement>();
        float defaultSpeed = playerMovement.playerSpeed;

        effectStart?.Invoke(this, EffectReciver);
        EffectGiver.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        playerMovement.playerSpeed *= 0.7f;
        EffectGiver.isStealthed = true;
        while (_currentDuration < _effectDuration)
        {
            _currentDuration += Time.deltaTime;
            yield return null;
        }
        effectEnd?.Invoke(this, EffectReciver);
        playerMovement.playerSpeed = defaultSpeed;
        EffectGiver.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        EffectGiver.isStealthed = false;

    }

    public override void Reset() {  }

    public EffectCloak(float effectDuration, Color effectColor, float effectValue, Sprite sprite)
    {
        _effectDuration = effectDuration;
        _effectColor = effectColor;
        _effectValue = effectValue;
        _effectSprite = sprite;
    }

}
