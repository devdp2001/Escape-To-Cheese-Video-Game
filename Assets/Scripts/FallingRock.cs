using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingRock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Tile")
        {
            Destroy(gameObject);
        }
        else if(other.tag == "Player")
        {
            SceneManager.LoadScene("Minigame2");
        }
    }
}
