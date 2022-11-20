using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
        } else
        {
            load();
        }
    }

    public void StartGame(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void Settings()
    {
        SceneManager.LoadScene("Options");
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainVolumeSlideChange()
    {
        AudioListener.volume = volumeSlider.value;
        save();
    }

    private void load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeSlider.value);
    }
}
