using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public void MoveScene()
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
