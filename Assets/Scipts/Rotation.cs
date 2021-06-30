using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float RotSpeed;
  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, RotSpeed * Time.deltaTime, 0);
    }
}
