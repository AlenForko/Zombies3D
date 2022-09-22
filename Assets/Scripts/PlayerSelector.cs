using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;

    private void Awake()
    {
        slider.maxValue = PlayerAmounts.maxAmount;
    }

    public void OnValuePlayerChange()
    {
        PlayerAmounts.PlayerAmount = (int)slider.value;
        sliderText.text = " " + slider.value;
    }
    public void OnValueZombieChange()
    {
        PlayerAmounts.ZombieAmount = (int)slider.value;
        sliderText.text = " " + slider.value;
    }
}
