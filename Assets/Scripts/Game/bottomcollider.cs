using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottomcollider : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D colliders;
    public bool playerIsBelow;

    void Start()
    {
        colliders = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsBelow = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsBelow = false;
        }
    }

}
