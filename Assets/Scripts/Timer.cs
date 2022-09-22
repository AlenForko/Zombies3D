using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _maxTime = 10.0f;

    public TextMeshProUGUI timeText;
    
    private void Update()
    {
        _maxTime -= Time.deltaTime;
        timeText.text = " " + (int)_maxTime;

        if (_maxTime <= 0f)
        {
            //End player turn.
        }
    }
}
