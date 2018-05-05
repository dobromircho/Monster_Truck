using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowColor : MonoBehaviour
{
    MeshRenderer arrow;
    
    void Start()
    {
        arrow = GetComponent<MeshRenderer>();
        arrow.material.color = new Color(Random.Range(0, 0.99f), Random.Range(0, 0.99f), Random.Range(0, 0.99f));
    }
    
}
