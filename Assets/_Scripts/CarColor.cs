using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarColor : MonoBehaviour
{
    MeshRenderer body;

    void Start()
    {
        body = GetComponent<MeshRenderer>();
        body.materials[1].color = new Color(Random.Range(0, 0.99f), Random.Range(0, 0.99f), Random.Range(0, 0.99f));
    }
    
}
