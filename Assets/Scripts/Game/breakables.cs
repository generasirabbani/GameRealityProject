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
    Animator anim;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        time = 0;
        anim = GetComponent<Animator>();
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
            StartCoroutine(breaks(0.2f));
        }
        if(bottomcollider.playerIsBelow && playerRB.velocity.magnitude >= breakVelocity)
        {
            StartCoroutine(breaks(0.2f));
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

    IEnumerator breaks(float time)
    {
        anim.SetTrigger("break");
        yield return new WaitForSeconds(time);
        this.gameObject.SetActive(false);
    }
}
