using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{

    Rigidbody Rb;
    AudioSource audio;
    [SerializeField] AudioClip MainEngine;
    [SerializeField] ParticleSystem MainBooster;
    [SerializeField] ParticleSystem LeftBooster;
    [SerializeField] ParticleSystem RightBooster;
    [SerializeField] float RocketForce;
    [SerializeField] float rotateForce;
    
  

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }






    // Update is called once per frame
    void Update()
    {
        ProcessRotation();
    }





     void FixedUpdate()
    {
        ProcessThrust();
    }






    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrustingandAudio();
        }

        else
        {
            StopSideMainThrustersandAudio();
        }
    }





    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ThrustLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ThrustRight();
        }
        else
        {
            StopSideThrusters();
        }
    }





    void StartThrustingandAudio()
    {
        Rb.AddRelativeForce(Vector3.up * RocketForce * Time.fixedDeltaTime);
        if (!audio.isPlaying)
        {
            audio.PlayOneShot(MainEngine);
        }
        if (!MainBooster.isPlaying)
        {
            MainBooster.Play();
        }
    }





    void ThrustRight()
    {
        ApplyRotation(-rotateForce);
      
        if (!RightBooster.isPlaying)
        {
            RightBooster.Play();
        }
    }






    void ThrustLeft()
    {
        ApplyRotation(rotateForce);
      
        if (!LeftBooster.isPlaying)
        {
            LeftBooster.Play();
        }
    }





    void StopSideThrusters()
    {
        LeftBooster.Stop();
        RightBooster.Stop();
       
    }





    void StopSideMainThrustersandAudio()
    {
        if (audio.isPlaying)
        {
            audio.Stop();
        }
      
        MainBooster.Stop();
    }





     void ApplyRotation(float rotationThisFrame)
    {
        Rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(0, 0, rotationThisFrame * Time.deltaTime);
        Rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
    }
  



  
}
