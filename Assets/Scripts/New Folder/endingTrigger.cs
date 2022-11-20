using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject finishPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            finishPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
