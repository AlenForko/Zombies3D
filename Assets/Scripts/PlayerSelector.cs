using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;

    private void Awake()
    {
        slider.maxValue = PlayerAmounts.ZombieAmount;
    }

    public void OnValueChange()
    {
        PlayerAmounts.PlayerAmount = (int)slider.value;
        sliderText.text = " " + slider.value;
    }
}
