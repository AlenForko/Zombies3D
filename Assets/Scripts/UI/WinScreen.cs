using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class WinScreen : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        private void Update()
        {
            MoveScene();
        }

        private void MoveScene()
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene(0);
            }
        }
    
        public void Exit()
        {
            Application.Quit();
        }
    }
}
