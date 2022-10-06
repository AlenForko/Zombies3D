using TMPro;
using UnityEngine;

namespace UI
{
    public class Timer : MonoBehaviour
    {
        private float _maxTime = 5.0f;
        public static float CurrentTime;
    
        public GameManager gameManager;

        public TextMeshProUGUI timeText;

        private void Start()
        {
            CurrentTime = _maxTime;
        }

        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                _maxTime = 100f;
                CurrentTime = _maxTime;
            }
            CurrentTime -= Time.deltaTime;
            timeText.text = "Time left: " + (int)CurrentTime + " ";
    
            if (CurrentTime <= 0f)
            {
                gameManager.GoToNextPlayer();
                CurrentTime = _maxTime;
            }
        }
    }
}
