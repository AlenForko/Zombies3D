using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector2 _turn;

    private float _maxY = -30f;
    private float _minY = 30f;

    private void Update()
    {
        _turn.y += Input.GetAxis("Mouse Y");
        _turn.y = Mathf.Clamp(_turn.y, _maxY, _minY);
        transform.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
    }
}
