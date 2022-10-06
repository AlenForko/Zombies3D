using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        public Gradient gradientColor;
        public Image fillImage;

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        public void SetHealth(int health)
        {
            slider.value = health;

            fillImage.color = gradientColor.Evaluate(slider.normalizedValue);
        }

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        
            fillImage.color = gradientColor.Evaluate(1f);
        }
    }
}
