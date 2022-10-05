using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _maxTime = 5.0f;
    public static float _currentTime;
    
    public GameManager GameManager;

    public TextMeshProUGUI timeText;

    private void Start()
    {
        _currentTime = _maxTime;
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F10))
        {
            _maxTime = 100f;
            _currentTime = _maxTime;
        }
        _currentTime -= Time.deltaTime;
        timeText.text = "Time left: " + (int)_currentTime + " ";
    
        if (_currentTime <= 0f)
        {
            GameManager.GoToNextPlayer();
            _currentTime = _maxTime;
        }
    }
}
