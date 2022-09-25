using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 _turn;
    private float _sensitivity = 2f;
    private float _maxY = -30f;
    private float _minY = 30f;

    private Transform player;
    public GameManager GameManager;

    public void SetCamera()
    {
        player = GameManager.currentPlayer.transform;
    }


    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");
        _turn.y = Mathf.Clamp(_turn. y, _maxY, _minY);
        transform.localRotation = Quaternion.Euler(0, -_turn.x, 0);
        transform.position = player.transform.position - player.transform.forward * 10f + player.transform.up * (_sensitivity * _turn.y);
        transform.LookAt(player);
    }
}
