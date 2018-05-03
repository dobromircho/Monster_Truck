using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NitroBottle : MonoBehaviour
{
    Transform bottle;
    public float timer;
    public bool isUp;
    public float rotSpeed;
    public ParticleSystem afterEffect;

    void Start()
    {
        bottle = GetComponentInChildren<Transform>();
    }
    
    void Update()
    {
        bottle.Rotate(0f, Time.deltaTime * rotSpeed, 0f);
        timer += Time.deltaTime;
        if (timer > 1)
        {
            isUp = !isUp;
            timer = 0;
        }

        if (isUp)
        {
            bottle.Translate(Vector3.up * Time.deltaTime);

        }
        else
        {
            bottle.Translate(Vector3.down * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            GameManager.GM.NitroArrowUp(150);
        }
        Instantiate(afterEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject,0.1f);
    }
}
