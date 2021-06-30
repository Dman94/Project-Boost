using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MissleHor : MonoBehaviour
{
    [SerializeField] float FireVelocity;
    [SerializeField] float Timer;
    [SerializeField] float RespawnRate;
    [SerializeField] MeshRenderer Body;
    [SerializeField] MeshRenderer Tail;
    [SerializeField] MeshRenderer Fin;



    void Start()
    {
        Body.enabled = false;
        Tail.enabled = false;
        Fin.enabled = false;
 
    }

    void Update()
    {
        HorizontalFire();
    }

    void HorizontalFire()
    {
        if (Time.time > Timer)
        {
            Body.enabled = true;
            Tail.enabled = true;
            Fin.enabled = true;

            transform.Translate(Vector3.up * FireVelocity * Time.deltaTime, Space.Self);
        }
    }
}
