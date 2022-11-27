using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public int comboPoints;
    public bool isStealthed;

    [SerializeField] private UnitStats _unitStats;
    public UnitStats unitStats { get; private set; }


    public enum UnitType { Player, Character }
    public UnitType unitType;   
    
    public ResourceSystem resourceSystem { get; private set; }

    private void Start()
    {
        unitStats = _unitStats;
        resourceSystem = GetComponent<ResourceSystem>();
    }

    private void OnMouseOver() 
    {
        GameManager.Instance.hoveredUnit = this;
    }
}
