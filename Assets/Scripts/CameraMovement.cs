using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;
    public GameManager gameManager;

    public void SetCamera()
    {
        _player = GameManager.currentPlayer.transform;
    }


    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 pos = _player.transform.position - _player.transform.forward * 10f + transform.up * 5f;
        transform.position = pos;
        transform.LookAt(_player);
    }
}
