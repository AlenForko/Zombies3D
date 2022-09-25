using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float maxTime = 10.0f;

    public TextMeshProUGUI timeText;
    
    private void Update()
    {
        maxTime -= Time.deltaTime;
        timeText.text = " " + (int)maxTime;

        if (maxTime <= 0f)
        {
            //End player turn.
        }
    }
}
