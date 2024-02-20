using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MinigameManager2 : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public TextMeshProUGUI  textBox;
    public float timeToWin;
    float timeToWinCounter;
    public float spawnTime;
    float timeUntilNextSpawn;
    bool legalState;
    bool isAWinnerWinner;

    // Start is called before the first frame update
    void Start()
    {
        isAWinnerWinner = false;
        legalState = false;
        timeToWinCounter = timeToWin;
        timeUntilNextSpawn = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAWinnerWinner)
        {
            textBox.text = "Time Left: " + math.round(timeToWinCounter);

            if(legalState)
            {
                if(timeToWinCounter > 0)
                {
                    if(timeUntilNextSpawn <= 0)
                    {
                        playGame();
                    }

                    timeUntilNextSpawn -= Time.deltaTime;
                    timeToWinCounter -= Time.deltaTime;
                }
                else
                {
                    win();
                }
            }
            else
            {
                stopGame();
            }
        }
    }

    private void win()
    {
        textBox.text = "Big Bean Burrito";
        isAWinnerWinner = true;
        SceneManager.LoadScene("StartingArea3");
    }


    private void stopGame()
    {
        timeToWinCounter = timeToWin;
        timeUntilNextSpawn = spawnTime;
        FallingRock[] obj = FindObjectsOfType<FallingRock>();
        foreach(FallingRock x in obj)
        {
            Destroy(x.gameObject);
        }
        Debug.Log("STOP");
    }


    private void playGame()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnObjects.Length);

        Vector3 spawnPoint = new Vector3(UnityEngine.Random.Range(-35,35), 20, UnityEngine.Random.Range(-20,50));

        Instantiate(spawnObjects[randomIndex], spawnPoint, Quaternion.identity);

        timeUntilNextSpawn = spawnTime;

    }


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            legalState = true;

        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            legalState = false;
        }
    }
}
