using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public GameObject Options;
    // Objects in UI
    public AudioMixer audioMixer;
    public Dropdown resolution;
    public Dropdown quality;
    public Toggle fullscreen;
    public Slider musicVolume;
    public Slider gameVolume;
    public Slider masterVolume;
    public Slider sensitivity;
    // Values for volume
    public float musicVolumeValue;
    public float gameVolumeValue;
    public float masterVolumeValue;
    public TMP_Text master;
    public TMP_Text music;
    public TMP_Text soundFX;
    public TMP_Text sens;


    // Index of Available Resolutions
    Resolution[] resolutions;
    void Start()
    {
        // Clear options in placeholder list
        resolution.ClearOptions();
        // Create a new list with current options
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        // Gets available options, formats them and adds them to the list
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height + " " + resolutions[i].refreshRate + "Hz";
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        musicVolumeValue = -20f;
        gameVolumeValue = -5f;
        resolution.AddOptions(options);
        resolution.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
        PlayerPrefs.SetFloat("Sensitivity", 2f);
        master.text = masterVolumeValue + "dB";
        music.text = musicVolumeValue + "dB";
        soundFX.text = gameVolumeValue + "dB";
        SetVolumeGame(gameVolumeValue);
        SetVolumeMaster(masterVolumeValue);
        SetVolumeMusic(musicVolumeValue);
        SetResolution(resolution.value);


    }
    // Calls the audioMixer and sets the respective volumes based on the volume sliders.
    public void SetVolumeMaster(float masterVolumeValue)
    {
        audioMixer.SetFloat("Master", masterVolumeValue);
        master.text = masterVolumeValue + "dB";
    }
    public void SetVolumeMusic(float musicVolumeValue)
    {
        audioMixer.SetFloat("Music", musicVolumeValue);
        music.text = musicVolumeValue + "dB";
    }
    public void SetVolumeGame(float gameVolumeValue)
    {
        audioMixer.SetFloat("soundFX", gameVolumeValue);
        soundFX.text = gameVolumeValue + "dB";
    }

    // Sets the game to and from fullscreen.
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    // Sets the chosen resolution.
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    // Sets the quality based on the option chosen from the dropdown menu.
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }
    public void SetSensitivity(float sensitivity)
    {
        sens.text = sensitivity + "";
    }
    
        

     
    // Commits settings to the PlayerPrefs.
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("QualitySetting", quality.value);
        PlayerPrefs.SetInt("ResolutionSetting", resolution.value);
        PlayerPrefs.SetInt("FullscreenSetting", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("Sensitivity", sensitivity.value);
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeValue);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeValue);
        PlayerPrefs.SetFloat("GameVolume", gameVolumeValue);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume.value);
        PlayerPrefs.SetFloat("GameVolume", gameVolume.value);
        PlayerPrefs.Save();

        Options.SetActive(false);
        Debug.Log(PlayerPrefs.GetFloat("Sensitivity"));

    }
    //Checks to see if a value has been set in the PlayerPrefs, if it hasnt, sets the default value, otherwise loads the saved setting.
    public void LoadSettings(int currentResolutionIndex)
    {
        if (PlayerPrefs.HasKey("QualitySetting"))
        {
            quality.value = PlayerPrefs.GetInt("QualitySetting");
        }
        else { quality.value = 2; }
        if (PlayerPrefs.HasKey("ResolutionSetting"))
        {
            resolution.value = PlayerPrefs.GetInt("ResolutionSetting");
        }
        else { resolution.value = currentResolutionIndex; }
        if (PlayerPrefs.HasKey("FullscreenSetting"))
        {
            Screen.fullScreen = Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenSetting"));
        }
        else { Screen.fullScreen = true; }
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolume.value = PlayerPrefs.GetFloat("MasterVolume");
            masterVolumeValue = PlayerPrefs.GetFloat("MasterVolume");
        }
        else { masterVolume.value = PlayerPrefs.GetFloat("MasterVolume"); masterVolumeValue = PlayerPrefs.GetFloat("MasterVolume"); }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
            musicVolumeValue = PlayerPrefs.GetFloat("MusicVolume");
        }
        else { musicVolume.value = PlayerPrefs.GetFloat("MusicVolume"); musicVolumeValue = PlayerPrefs.GetFloat("MusicVolume"); }
        if (PlayerPrefs.HasKey("GameVolume"))
        {
            gameVolume.value = PlayerPrefs.GetFloat("GameVolume");
            gameVolumeValue = PlayerPrefs.GetFloat("GameVolume");
        }
        else { gameVolume.value = PlayerPrefs.GetFloat("GameVolume"); gameVolumeValue = PlayerPrefs.GetFloat("GameVolume"); }
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            sensitivity.value = PlayerPrefs.GetFloat("Sensitivity");
        }
        else { sensitivity.value = 1f; sensitivity.value = PlayerPrefs.GetFloat("Sensitivity"); }
    }
}
