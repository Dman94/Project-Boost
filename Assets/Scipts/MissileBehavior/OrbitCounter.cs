using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCounter : MonoBehaviour
{
    [SerializeField] float RotationSpeed;
    [SerializeField] Vector3 RotationPoint;
    [SerializeField] GameObject SelectedRotPointOrigin;



    // Update is called once per frame
    void Update()
    {
        MissileRotate();
    }
    void MissileRotate()
    {
        RotationPoint = SelectedRotPointOrigin.transform.position;
        transform.RotateAround(RotationPoint, SelectedRotPointOrigin.transform.forward, -RotationSpeed * Time.deltaTime);
    }
}
