using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{

    GameObject[] tiles;
    // Start is called before the first frame update
    void Start()
    {
        tiles = GameObject.FindGameObjectsWithTag("Tile");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TileChecker()
    {
        foreach (GameObject x in tiles)
        {
            if(x.GetComponent<Renderer>().material.color != Color.green)
            {
                Debug.Log("MORE");
                return;
            }
        }
        SceneManager.LoadScene("StartingArea2");

    }
}
