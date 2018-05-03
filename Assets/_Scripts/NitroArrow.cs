
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroArrow : MonoBehaviour
{
    public Slider sliderFuel;
    public Slider sliderNitro;
    public static NitroArrow arrow;
    public float minRot;
    public float maxRot;
    float zRot;
    public float value;
    public float oldValue;
    public float timer;

    void Start()
    {
        arrow = this;
        oldValue = value;
    }
    
    void Update()
    {
        sliderNitro.value = value * -1;

        if (oldValue != value)
        {
            timer += Time.deltaTime;
            this.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(oldValue,value, timer * 2));
            if (timer > 0.5f)
            {
                oldValue = value;
                timer = 0;
            }
        }
        if (value > 0)
        {
            value = 0;
        }
        if (value < -265)
        {
            value = -265;
        }
    }
}
