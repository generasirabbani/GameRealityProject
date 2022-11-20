using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuManage : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausemenu;
    public bool isPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            doPause();
        }
        if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            doResume();
        }
    }

    public void doPause()
    {
        Time.timeScale = 0f;
        pausemenu.SetActive(true);
    }

    public void changeSceneByName(string name)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(name);
    }

    public void doResume()
    {
        Time.timeScale = 1.0f;
        pausemenu.SetActive(false);
    }

    public void rePlay()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
