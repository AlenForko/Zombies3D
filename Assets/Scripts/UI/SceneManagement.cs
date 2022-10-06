using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneManagement : MonoBehaviour
    {
        public GameObject mainMenu;
        public GameObject selectionMenu;
        public GameObject settingsMenu;

        public void ReturnToMainMenu()
        {
            mainMenu.SetActive(true);
            selectionMenu.SetActive(false);
            settingsMenu.SetActive(false);
        }

        public void SettingsMenu()
        {
            settingsMenu.SetActive(true);
            mainMenu.SetActive(false);
            selectionMenu.SetActive(false);
        }

        public void SelectMenu()
        {
            mainMenu.SetActive(false);
            selectionMenu.SetActive(true);
            settingsMenu.SetActive(false);
        }

        public void StartGame(int sceneID)
        {
            SceneManager.LoadScene(sceneID);
        }
    

        public void ExitGame()
        {
            Debug.Log("Exiting game..");
            Application.Quit();
        }
    }
}