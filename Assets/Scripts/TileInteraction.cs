using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileInteraction : MonoBehaviour
{
    private Color oColor; 
    private Color nColor; 
    // Start is called before the first frame update
    void Start()
    {
        oColor = GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("MPlayer")){
            Debug.Log("Trigger with Player detected!");
            GetComponent<Renderer>().material.color = nColor;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
