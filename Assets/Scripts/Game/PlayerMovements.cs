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


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            playerMove();
        }
        dirPointer(startPoint, currentPoint);
    }

    void playerMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            directPointerSprite.SetActive(true);

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
        }
    }

    void dirPointer(Vector3 startPoint,Vector3 endPoint)
    {
        //var dir = startPoint - endPoint;
        //var rot = Quaternion.LookRotation(dir,Vector3.up);
        //directPointer.transform.rotation = rot;
        float rota = Mathf.Atan2((endPoint.y - startPoint.y),(endPoint.x - startPoint.x)) * Mathf.Rad2Deg;
        directPointer.transform.rotation = Quaternion.Euler(0, 0, rota);
    }
}
