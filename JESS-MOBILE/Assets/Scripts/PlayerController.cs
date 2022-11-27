using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Rigidbody2D playerBody { get; private set; }
    public ResourceSystem resourceSystem { get; private set; }
    public GameUnit gameUnit { get; private set; }

    private void Start()
    {
        resourceSystem = GetComponent<ResourceSystem>();
        playerBody = GetComponent<Rigidbody2D>();
        gameUnit = GetComponent<GameUnit>();

        Instance = this;
    }
}
