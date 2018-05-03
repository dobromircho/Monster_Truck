using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBarrels : MonoBehaviour
{
    public Material[] barrels;
    public float timer;
    public bool isUp;
    MeshRenderer thisBarrel;
    int randBarrel;
    bool isColor;
    public ParticleSystem afterEffect;

    void Start()
    {
        thisBarrel = GetComponentInChildren<MeshRenderer>();
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            isUp = !isUp;
            timer = 0;
        }

        if (isUp)
        {
            transform.Translate(Vector3.up * Time.deltaTime);

        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        if (!isColor)
        {
            randBarrel = Random.Range(0, barrels.Length);
            thisBarrel.material = barrels[randBarrel];
            isColor = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "car")
        {
            GameManager.GM.IncreaseFuel(30);
        }
        Instantiate(afterEffect, this.transform.position, Quaternion.identity);
        Destroy(gameObject,0.2f);
    }
}
