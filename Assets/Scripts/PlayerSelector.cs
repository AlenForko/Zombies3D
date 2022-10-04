using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;

    private void Awake()
    {
        slider.maxValue = PlayerAmounts.MaxAmount;
        slider.minValue = 1;
    }

    public void OnValuePlayerChange()
    {
        PlayerAmounts.PlayerAmount = (int)slider.value;
        sliderText.text = " " + slider.value;
        slider.minValue = 2;
    }
    public void OnValueZombieChange()
    {
        PlayerAmounts.ZombieAmount = (int)slider.value;
        sliderText.text = " " + slider.value;
    }
}
