using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{   
    [SerializeField] float ReloadDelay = 1f;
    [SerializeField] ParticleSystem CrashEffect;
    [SerializeField] AudioClip CrashSound;
    bool crashSound = true;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Ground")
        {   
            FindObjectOfType<PlayerController>().DisableControls();
            if (crashSound){
                CrashEffect.Play();
                crashSound = false;
            }
            GetComponent<AudioSource>().PlayOneShot(CrashSound);
            Invoke("ReloadScene", ReloadDelay); 
            
        }
        
    }
    void ReloadScene()
    {
         SceneManager.LoadScene(0);
    }
}