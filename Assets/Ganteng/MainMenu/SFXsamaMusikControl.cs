using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SFXsamaMusikControl : MonoBehaviour
{
    public Slider Sliderr;
    public AudioSource Sourcenya;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
        }
        else
        {
            load();
        }
    }

    public void Volumee()
    {
        Sourcenya.volume = Sliderr.value;
        save();
    }

    private void save()
    {
        PlayerPrefs.SetFloat("musicvolume", Sliderr.value);
    }

    private void load()
    {
        Sliderr.value = PlayerPrefs.GetFloat("musicvolume");
    }
}
