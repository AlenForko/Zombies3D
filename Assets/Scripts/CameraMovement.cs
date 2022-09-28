using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform player;
    public GameManager GameManager;

    public void SetCamera()
    {
        player = GameManager.currentPlayer.transform;
    }


    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 pos = player.transform.position - player.transform.forward * 10f + transform.up * 5f;
        transform.position = pos;
        transform.LookAt(player);
    }
}
