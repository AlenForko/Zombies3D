using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectionMenu;
    
  

    public void ReturnToMainMenu()
    {
        mainMenu.SetActive(true);
        selectionMenu.SetActive(false);
    }

    public void SelectMenu()
    {
        mainMenu.SetActive(false);
        selectionMenu.SetActive(true);
    }
    
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game..");
        Application.Quit();
    }
}