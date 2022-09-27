using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 _turn;
    private float _sensitivity = 2f;

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
        _turn.y += Input.GetAxis("Mouse Y");
        Vector3 pos = player.transform.position - player.transform.forward * 10f 
                      + player.transform.up * (_sensitivity * _turn.y);
        transform.position = new Vector3(pos.x,
            (player.transform.position.y + 2) + Mathf.Clamp( _turn.y * _sensitivity,0,10), pos.z);
        transform.LookAt(player);
    }
}
