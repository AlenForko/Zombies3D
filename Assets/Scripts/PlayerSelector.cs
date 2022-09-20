using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI sliderText;

    public int amountOfPlayers;
    private int maxPlayerAmount = 4;

    private void Awake()
    {
        slider.maxValue = maxPlayerAmount;
    }

    private void Update()
    {
        slider.value += amountOfPlayers;
        sliderText.text = " " + slider.value;
    }
}
