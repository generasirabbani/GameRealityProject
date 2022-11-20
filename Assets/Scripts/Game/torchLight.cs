using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.Rendering.Universal;

public class torchLight : MonoBehaviour
{
    // Start is called before the first frame update
    Light2DBase lights;
    Light2D Lights;
    void Start()
    {
        Lights = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Lights.intensity = Mathf.PingPong(Time.time/10, 0.1f) + 0.2f;
    }
}
