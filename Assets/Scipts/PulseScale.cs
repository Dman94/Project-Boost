using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseScale : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 StartingScale;
    [SerializeField] Vector3 ScaleVector;
    [SerializeField] [Range(0, 1)] float ScaleFactor;
    [SerializeField] float ScalingPeriod = 2f;


    void Start()
    {
       
        StartingScale = transform.localScale;

    }
    // Update is called once per frame
    void Update()
    {
     
        OscillateScale();
    }

    void OscillateScale()
    {
        if (ScalingPeriod <= Mathf.Epsilon) { return; }
        float Cycles = Time.time / ScalingPeriod; // Continually growing over time

        const float Tau = Mathf.PI * 2; // constant value of 6.283
        float RawSinWave = Mathf.Sin(Cycles * Tau); //going from -1 to 1

        ScaleFactor = (RawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 OffSet = ScaleVector * ScaleFactor;
        transform.localScale = StartingScale + OffSet;
    }
}
