using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Unit/UnitStats", fileName = "UnitStats")]
public class UnitStats : ScriptableObject
{
    [Header("Stats")]
    public string unitName;
    public float criticalRate;
    public float criticalDamage;
    public float healthRegeneration;
    public float resourceRegeneration;

    [Header("Stats Rate")]
    public float healthRate;
    public float resourceRate;
}
