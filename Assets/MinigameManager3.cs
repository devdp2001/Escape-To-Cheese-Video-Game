using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager3 : MonoBehaviour
{
    public bool godMode;
    // Start is called before the first frame update
    void Start()
    {
        godMode = false;   
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            godMode = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        godMode = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
