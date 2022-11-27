using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput playerInput { get; private set; }
    public Vector2 moveDirection { get; private set; }

    public float playerSpeed;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        moveDirection = new Vector2 (input.x, input.y);

        //if (moveDirection.y == 0) { animator.Play("anim-die"); }
        //else if (moveDirection.y > Mathf.Epsilon) { animator.Play("anim-walk-2"); facingUp = false; }
        //else if (moveDirection.y < Mathf.Epsilon) { animator.Play("anim-walk-1"); facingUp = true; }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigidbody = PlayerController.Instance.playerBody;
        rigidbody.velocity = moveDirection * playerSpeed;
    }
}
