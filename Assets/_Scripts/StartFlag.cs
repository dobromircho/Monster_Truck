using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFlag : MonoBehaviour
{
    private void Start()
    {
        CapsuleCollider[] cc = new CapsuleCollider[1];
        cc[0] = GameObject.FindWithTag("car").GetComponent<CapsuleCollider>();
        transform.GetComponent<Cloth>().capsuleColliders = cc;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.tag == "startFlag")
        {
            if (other.tag == "car")
            {
                GameManager.GM.PlayMusic();
            }
        }
        
    }

}
