using Player;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cursor = UnityEngine.Cursor;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        public GameObject pausingMenu;
        private CameraMovement _cameraMovement;

        public static bool GameIsPaused;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Pause();
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }

        private void Pause()
        {
            pausingMenu.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
        }

        private void Resume()
        {
            pausingMenu.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        }

        public void BackToMainMenu(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
            Time.timeScale = 1f;
        }
    }
}
