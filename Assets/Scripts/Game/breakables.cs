using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakables : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerIsAbove;
    public float breakTime;
    public bool playerIsBelow;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAbove)
        {
            StartCoroutine(breaks(breakTime));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsAbove = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsAbove = false;
        }
    }
    

    IEnumerator breaks(float time)
    {
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
