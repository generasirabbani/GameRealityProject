using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayernonsmoothed : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
    }
}
