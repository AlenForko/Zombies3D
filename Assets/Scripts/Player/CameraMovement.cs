using UnityEngine;

namespace Player
{
    public class CameraMovement : MonoBehaviour
    {
        private Transform _player;

        public void SetCamera()
        {
            _player = GameManager.CurrentPlayer.transform;
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
}
