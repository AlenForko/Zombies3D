using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 turn;

    private float maxY = -30f;
    private float minY = 30f;

    private void Update()
    {
        turn.y += Input.GetAxis("Mouse Y");
        turn.y = Mathf.Clamp(turn.y, maxY, minY);
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
    }
}
