using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public Canvas canvas;
    
    public void PausedMenu()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }

    public void BackToMainMenu(int sceneID)
    {
        SceneManager.LoadScene(0);
    }
}
