using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Effect
{
    public float _currentDuration;
    public float _effectDuration;

    public GameObject _effectObjectUI;

    public Color _effectColor;
    public float _effectValue;

    public Action<Effect, GameUnit> effectStart;
    public Action<Effect, GameUnit> effectEnd;

    public abstract IEnumerator Apply(GameUnit reciver, GameUnit giver);
    public abstract void Reset();
}
