using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum MoveDirection { LEFT, RIGHT, UP, DOWN, NONE}
    private MoveDirection moveDirection;

    [SerializeField] private float playerSpeed;
    private void Update()
    {
        if (Input.GetKey(KeyCode.W)) { moveDirection = MoveDirection.UP; }
        else if (Input.GetKey(KeyCode.A)) { moveDirection = MoveDirection.LEFT; }
        else if (Input.GetKey(KeyCode.S)) { moveDirection = MoveDirection.DOWN; }
        else if (Input.GetKey(KeyCode.D)) { moveDirection = MoveDirection.RIGHT; }
        else { moveDirection = MoveDirection.NONE; }

        //Debug
        if (Input.GetKeyDown(KeyCode.F1)) { GetComponent<ResourceSystem>().ReduceHealth(10); }
        if (Input.GetKeyDown(KeyCode.F2)) { GetComponent<ResourceSystem>().ReduceResource(10); }
    }

    private void FixedUpdate()
    {
        Rigidbody2D rigidbody = PlayerController.Instance.playerBody;
        switch (moveDirection)
        {
            case MoveDirection.LEFT:
                if (AbilityTools.currentlyCasting == true) { GameManager.Instance.moveDurationCast?.Invoke(); }
                rigidbody.velocity = new Vector2(-playerSpeed, 0);
                break;
            case MoveDirection.RIGHT:
                if (AbilityTools.currentlyCasting == true) { GameManager.Instance.moveDurationCast?.Invoke(); }
                rigidbody.velocity = new Vector2(playerSpeed, 0);
                break;
            case MoveDirection.UP:
                if (AbilityTools.currentlyCasting == true) { GameManager.Instance.moveDurationCast?.Invoke(); }
                rigidbody.velocity = new Vector2(0, playerSpeed);
                break;
            case MoveDirection.DOWN:
                if (AbilityTools.currentlyCasting == true) { GameManager.Instance.moveDurationCast?.Invoke(); }
                rigidbody.velocity = new Vector2(0, -playerSpeed);
                break;
            case MoveDirection.NONE:
                rigidbody.velocity = Vector2.zero;
                break;
        }
    }
}
