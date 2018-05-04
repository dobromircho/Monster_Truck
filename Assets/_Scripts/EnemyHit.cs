using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        sound.Play();
    }
}
