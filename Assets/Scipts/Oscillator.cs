using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 StartingPosition;
    Vector3 StartingScale;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] Vector3 ScaleVector;
    [SerializeField] [Range(0,1)] float MovementFactor;
    [SerializeField] [Range(0, 1)] float ScaleFactor;
    [SerializeField] [Range(0, 1)] float RotateFactor;
    [SerializeField] float MovementPeriod = 2f;
    [SerializeField] float ScalingPeriod = 2f;


   

    void Start()
    {
        StartingPosition = transform.position;
        StartingScale = transform.localScale;
       
    }





    // Update is called once per frame
    void Update()
    {
        OscillateTransform();
        OscillateScale();
    }






    void OscillateTransform()
    {
        if (MovementPeriod <= Mathf.Epsilon) { return; }
        float Cycles = Time.time / MovementPeriod; // Continually growing over time

        const float Tau = Mathf.PI * 2; // constant value of 6.283
        float RawSinWave = Mathf.Sin(Cycles * Tau); //going from -1 to 1

        MovementFactor = (RawSinWave + 1f) / 2f; // recalculated to go from 0 to 1

        Vector3 OffSet = MovementVector * MovementFactor;
        transform.position = StartingPosition + OffSet;
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
