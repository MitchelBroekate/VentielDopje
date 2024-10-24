using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.UI;  

public class Settings : MonoBehaviour
{
    [Header("VolumeSliders")]
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider sfxSlider;


    [Header("Resolutions")]
    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    private List<Resolution> filteredResolution;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;

    public Volume volume;
    public Slider gammaSlider;
    public LiftGammaGain liftGammaGain;


    [System.Obsolete]
    public void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    
        resolutions = Screen.resolutions;
        filteredResolution = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolution.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolution.Count; i++)
        {
            string resolutionOption = filteredResolution[i].width + "X" + filteredResolution[i].height + " ";
            options.Add(resolutionOption);

            if (filteredResolution[i].width == Screen.width && filteredResolution[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

       

        float savedGamma = PlayerPrefs.GetFloat("Gamma", 1f);
        gammaSlider.value = savedGamma;

        if (volume.profile.TryGet(out liftGammaGain))
        {
            
            Vector4 gamma = liftGammaGain.gamma.value;
            gamma.w = savedGamma; 
            liftGammaGain.gamma.value = gamma;

           
            gammaSlider.onValueChanged.AddListener(UpdateGamma);

        }

    }
 


    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolution[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetMusic(float sliderValue)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
       
    }

    public void SetSFX(float sliderValue)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    public void UpdateGamma(float sliderValue)
    {
       

        if (liftGammaGain != null)
        {

            PlayerPrefs.SetFloat("Gamma", sliderValue);
            Vector4 gamma = liftGammaGain.gamma.value;
            gamma.w = sliderValue;
            liftGammaGain.gamma.value = gamma;
            
        }

    }



    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}

