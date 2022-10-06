using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace UI
{
    public class SettingsMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;
    
        private Resolution[] _resolutions;
        public TMP_Dropdown resolutionDropdown;
        private void Start()
        {
            _resolutions = Screen.resolutions;
        
            resolutionDropdown.ClearOptions();

            List<string> options = new List<string>();

            int currentResIndex = 0;
            for (int i = 0; i < _resolutions.Length; i++)
            {
                string option = _resolutions[i].width + "x" + _resolutions[i].height + "@" + _resolutions[i].refreshRate;
                options.Add(option);
                if (_resolutions[i].width == Screen.currentResolution.width && _resolutions[i].height == Screen.currentResolution.height && _resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
                {
                    currentResIndex = i;
                }
            }
            resolutionDropdown.AddOptions(options);
            resolutionDropdown.value = currentResIndex;
            resolutionDropdown.RefreshShownValue();
        }

        public void SetResolution(int resIndex)
        {
            Resolution resolution = _resolutions[resIndex];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        public void SetVolume(float sliderValue)
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
            PlayerPrefs.SetFloat("Volume", Mathf.Log10(sliderValue) * 20);
        }

        public void SetQuality(int qualityIndex)
        {
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        public void Fullscreen(bool isFullscreen)
        {
            Screen.fullScreen = isFullscreen;
        }
    }
}
