using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droper : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float DropTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

    }
    private void FixedUpdate()
    {
        if(Time.time == DropTimer)
        {
            rb.useGravity = true;
        }
        
    }
}
