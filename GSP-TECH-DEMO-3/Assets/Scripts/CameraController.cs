using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Update()
    {
        Transform playerTransform = PlayerController.Instance.transform;
        transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
