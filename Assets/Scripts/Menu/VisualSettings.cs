using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VisualSettings : MonoBehaviour
{
    [SerializeField] GameObject confirmationPrompt = null;

    [SerializeField] private Slider brightnessSlider = null;
    [SerializeField] private TMP_Text brightnessTxtValue = null;
    [SerializeField] private float defaultBrightness = 1;


    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;


    private int _qualityLevel;
    [SerializeField] bool _isFullScreen;
    private float _brightnessLevel;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);


            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        brightnessTxtValue.text = brightness.ToString("0.0");
    }
    
    public void SetFullScreen(bool isFullScreen)
    {
        _isFullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        _qualityLevel = qualityIndex;
    }

    public void ApplyGraph()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);
        //
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);
        //
        PlayerPrefs.SetInt("isFullScreen", (_isFullScreen ? 1 : 0));
        Screen.fullScreen = _isFullScreen;

        StartCoroutine(ConfrimationBox());
    }

    public IEnumerator ConfrimationBox()
    {
        confirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);

        confirmationPrompt.SetActive(false);
    }





    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
