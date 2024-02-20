using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Created By: Dev Patel
/// Date:       10/23/2023
///     Implementation for players life.
///     When rat is "Captured", it stops movement and game object
///     from screen and reloads the scene.

public class PlayerLife : MonoBehaviour
{
    public AudioClip capturedSoundEffect;
    private AudioSource audioSource;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim  = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (capturedSoundEffect != null)
        {
            audioSource.clip = capturedSoundEffect;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetBool("isDead", true);
            Captured();
        }
    }

    public void Captured()
    {
        PlayCaptureSound();
        GetComponent<Rigidbody>().isKinematic = true;
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<NewPlayerMovement>().enabled = false;
        Invoke("ReloadLevel", 1.0f);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    private void PlayCaptureSound()
    {
        if (audioSource != null && capturedSoundEffect != null)
        {
            audioSource.PlayOneShot(capturedSoundEffect);
        }
    }
}

