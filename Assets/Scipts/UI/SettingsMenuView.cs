using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenuView : View
{
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private TMP_Dropdown graphicsDropdown;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Button backButton;

    [SerializeField] private AudioMixer audioMixer;
    Resolution[] resolutions;

    public override void Initialize()
    {
        //Add the resolution options to the resolution dropdown
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " @" + resolutions[i].refreshRate + "Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        //Set all listeners for the UI elements
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value);});
        fullscreenToggle.onValueChanged.AddListener(delegate { SetFullscreen(fullscreenToggle.isOn); });
        graphicsDropdown.onValueChanged.AddListener(delegate { SetQuality(graphicsDropdown.value); });
        volumeSlider.onValueChanged.AddListener(delegate { SetVolume(volumeSlider.value); });
        backButton.onClick.AddListener(() => ViewManager.ShowLast());
    }

    private void SetResolution ( int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void SetVolume(float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

    private void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    private void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
