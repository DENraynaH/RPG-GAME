using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnit : MonoBehaviour
{
    public string unitName;
    
    
    public ResourceSystem resourceSystem { get; private set; }

    private void Start()
    {
        resourceSystem = GetComponent<ResourceSystem>();
    }

    private void OnMouseOver() 
    {
        GameManager.Instance.hoveredUnit = this;
    }
}
