using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform target;
    Transform tempTarget;
    public float distance;
    public float speed;
    Animator animator;
    public bool isPaused;
    public float timerPaused;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        tempTarget = target;
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            isPaused = true;
        }
        if (isPaused)
        {
            timerPaused += Time.deltaTime;
            animator.SetBool("isPaused", true);
            if (timerPaused >= 5)
            {
                animator.SetBool("isPaused", false);
                timerPaused = 0;
                isPaused = false;
            }
        }
        transform.LookAt(target);
        if (distance > 7 && distance < 100)
        {
            transform.Translate(new Vector3(0, 1f * speed * Time.deltaTime, 1 * speed * Time.deltaTime));
        }
        if (distance > 50)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
        distance = Vector3.Distance(this.transform.position, target.position);
        animator.SetFloat("distance", distance);
    }
}
