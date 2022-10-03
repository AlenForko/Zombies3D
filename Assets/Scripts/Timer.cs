using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _maxTime =2.0f;
    public static float _currentTime;
    
    public GameManager GameManager;

    public TextMeshProUGUI timeText;

    private void Start()
    {
        _currentTime = _maxTime;
    }

    private void LateUpdate()
    {
        _currentTime -= Time.deltaTime;
        timeText.text = " " + (int)_currentTime;
    
        if (_currentTime <= 0f)
        {
            GameManager.GoToNextPlayer();
            _currentTime = _maxTime;
        }
    }
}
