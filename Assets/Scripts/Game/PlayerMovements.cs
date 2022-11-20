using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    //numerical value
    public float throwPower = 10f;
    public Vector2 minPower;
    public Vector2 maxPower;
    public Vector2 force;
    public float velocityVal;

    //booleanValue
    public bool isGrounded = true;

    //referencing
    public Rigidbody2D rb;
    public Camera cam;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 currentPoint;
    public GameObject groundChecker;
    public GameObject directPointer;
    public GameObject directPointerSprite;
    public Collider2D groundCheckCollider;
    public LayerMask groundLayer;
    Animator animator;
    public AudioSource audioSource;
    public menuManage menu;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        groundCheckCollider = groundChecker.GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        velocityVal = rb.velocity.magnitude;
        groundCheck();
        animator.SetBool("isGrounded",isGrounded);
        if (isGrounded && menu.isPaused == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerMove();
            dirPointer(startPoint, currentPoint);
        }
        if (!isGrounded)
        {
            rotateOnAir();
        }
    }

    void playerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            directPointerSprite.SetActive(true);
            animator.SetBool("isCharging", true);

        }
        if (Input.GetMouseButton(0))
        {
            currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * throwPower, ForceMode2D.Impulse);
            directPointerSprite.SetActive(false);
            animator.SetBool("isCharging",false);
        }
    }

    void dirPointer(Vector3 startPoint,Vector3 endPoint)
    {
        //var dir = startPoint - endPoint;
        //var rot = Quaternion.LookRotation(dir,Vector3.up);
        //directPointer.transform.rotation = rot;
        float rota = Mathf.Atan2((endPoint.y - startPoint.y),(endPoint.x - startPoint.x)) * Mathf.Rad2Deg;
        directPointer.transform.rotation = Quaternion.Euler(0, 0, rota);
        if(Mathf.Abs(rota) <= 90)
        {
            transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
        }
        if(Mathf.Abs(rota) >= 90)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    void groundCheck()
    {
        float extraHeight = 0.5f;
        isGrounded = Physics2D.BoxCast(groundCheckCollider.bounds.center, groundCheckCollider.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);
    }

    void rotateOnAir()
    {
        //transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        Vector2 v = rb.velocity;
        float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            audioSource.Play();
        }

    }
}
