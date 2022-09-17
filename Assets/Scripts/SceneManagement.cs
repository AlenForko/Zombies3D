using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void MoveScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    public void ExitGame()
    {
        SceneManager.Application.Quit();
    }
}