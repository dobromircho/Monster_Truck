using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFading : MonoBehaviour
{
    Light sun;
    float intensity;
    public float timerLight;
    public float timerDay;
    public float timeToSwitch;
    public bool isDaylight;


    void Start()
    {
        sun = GetComponent<Light>();
        sun.intensity = 0.5f;
        isDaylight = true;
    }
    
    void Update()
    {
        timerLight += Time.deltaTime;
        timerDay += Time.deltaTime;

        if (timerDay >= timeToSwitch)
        {
            isDaylight = !isDaylight;
            timerDay = 0;
        }
        
        if (isDaylight)
        {
            LightUp();
        }

        if (!isDaylight)
        {
            LightDown();
        }
    }

    public void LightDown()
    {
        if (timerLight >= 1 && sun.intensity > 0f)
        {
            sun.intensity -= 0.1f;
            timerLight = 0;
        }
        
    }

    public void LightUp()
    {
        if (timerLight >= 1 && sun.intensity < 1f)
        {
            sun.intensity += 0.1f;
            timerLight = 0;
        }
        
    }
}
