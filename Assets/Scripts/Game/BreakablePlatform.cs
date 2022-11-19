using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public bool playerIsAbove;
    public float respTime;
    public breakables[] detectors;
    public List<GameObject> breakableplatforms = new List<GameObject>();
    public Animator anim;

    void Start()
    {
        detectors = GameObject.FindObjectsOfType<breakables>();
        foreach(breakables detector in detectors){
            breakableplatforms.Add(detector.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
       foreach(GameObject breakable in breakableplatforms)
        {
            if (!breakable.activeSelf)
            {
                StartCoroutine(onRespPlat(breakable,respTime));
            }
        }
    }

    IEnumerator onRespPlat(GameObject plat, float time)
    {
        yield return new WaitForSeconds(time);
        plat.SetActive(true);
    }



}
