using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
  
    [SerializeField] AudioClip Explosion;
    [SerializeField] AudioClip Success;
    [SerializeField] ParticleSystem ExplosionParticle;
    [SerializeField] ParticleSystem SuccessParticle;
    AudioSource audio;
    
    [SerializeField] MeshRenderer Body;
    [SerializeField] MeshRenderer UpperWings;
    [SerializeField] MeshRenderer LowerWings;
    [SerializeField] MeshRenderer UpperTail;
    [SerializeField] MeshRenderer LowerTail;
    [SerializeField] MeshRenderer Window;
    [SerializeField] MeshRenderer LeftThruster;
    [SerializeField] MeshRenderer RightThruster;
    [SerializeField] float ReloadDelay;
    [SerializeField] float NextLevelDelay;
  

    public bool IsTransitioning;
    bool collisionDisabled = false;





    void Start()
    {
         IsTransitioning = false;
         audio = GetComponent<AudioSource>();
    }





    void Update()
    {
       // RespondtoDebugKeys();
    }





    void RespondtoDebugKeys()
    {
        LoadLevelsAndDisableCollision();
    }






     void LoadLevelsAndDisableCollision()
    {
        if(Input.GetKeyDown(KeyCode.L)) LoadNextLevel();
      
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
    }






    void OnCollisionEnter(Collision other)
    {
        if(IsTransitioning == true || collisionDisabled) { return; }
        

        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Take off!");
                break;
            case "Finish":
                Debug.Log("Finish!");
                StartSuccessSequence(other);             
                break;
            case "Meteor":
                Debug.Log("You've hit a meteor!");
                StartCrashSequence();
                break;
            case "Missle":
                Debug.Log("You've hit a missle!");
                StartCrashSequence();
                break;
            default:
                StartCrashSequence();
                break;
        } 
     }
    





   private void StartCrashSequence()
    {
        IsTransitioning = true;
        audio.Stop();
        audio.PlayOneShot(Explosion);
        ExplosionParticle.Play();
        Invoke("ReloadLevel", ReloadDelay);
        GetComponent<Movement>().enabled = false;
        DisableRocketMeshRend();

    }






    private void StartSuccessSequence(Collision other)
    {
        IsTransitioning = true;
        audio.Stop(); //since we are playing the MainEngine clip first it will stop that one then proceed to the Success Clip
        audio.PlayOneShot(Success);
        SuccessParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", NextLevelDelay);
    }
    





void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);  
    }





   void LoadNextLevel()
    {
       
        int CurrentsceneIndex = SceneManager.GetActiveScene().buildIndex;
        int neNextSceneIndex = CurrentsceneIndex + 1;

        if (neNextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            neNextSceneIndex = 0;
            SceneManager.LoadScene(neNextSceneIndex);
        }
        SceneManager.LoadScene(neNextSceneIndex);
    }






    void DisableRocketMeshRend()
    {
        Body.enabled = false;
        UpperWings.enabled = false;
        LowerWings.enabled = false;
        UpperTail.enabled = false;
        LowerTail.enabled = false;
        LeftThruster.enabled = false;
        RightThruster.enabled = false;
        Window.enabled = false;
    }

}









