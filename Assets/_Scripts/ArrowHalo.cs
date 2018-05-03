using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHalo : MonoBehaviour
{
    public GameObject halo;
    public float timeToBlink;
    float timer;
    bool isHaloOn;

    void Start()
    {

    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToBlink)
        {
            isHaloOn = !isHaloOn;
            timer = 0;
        }
        if (isHaloOn)
        {
            halo.gameObject.SetActive(true);
        }
        else
        {
            halo.gameObject.SetActive(false);
        }

    }
}
