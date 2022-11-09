using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Rigidbody2D playerBody;

    private void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
        Instance = this;
    }
}
