using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakables : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerIsAbove;
    public float breakTime;
    public bool playerIsBelow;
    public float time = 0;
    public float breakVelocity;
    public GameObject player;
    Rigidbody2D playerRB;
    public bottomcollider bottomcollider;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAbove)
        {
            time += Time.deltaTime;
        }
        if(time > breakTime)
        {
            breaks();
        }
        if(bottomcollider.playerIsBelow && playerRB.velocity.magnitude >= breakVelocity)
        {
            breaks();
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
            time = 0;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
        //if (collision.gameObject.CompareTag("Player") && playerRB.velocity.magnitude >= breakVelocity)
        //{
            //breaks();
        //}

    //}

    void breaks()
    {
        this.gameObject.SetActive(false);
    }
}
