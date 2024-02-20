using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// Created By: Soughtout Olasupo-Ojo
///             Implemented tracking of the path player has taken and lights up
///             the panels.
/// 
/// Modified By: Sophia Wu
/// Date:        10/30/2023
///              Modified to have a solution path that the player must complete.
///              Commented out MinigameManager as it is now deprecated.
///              Implemented sounds when tile is pressed.
///              AudioSource component is required on the attach GameObject for sounds to work.

public class TilePress : MonoBehaviour
{
    [SerializeField] AudioClip tilePressAudio;
    GameObject rat;

    //MinigameManager manager;
    private List<string> pathTaken; // The path the player has taken so far 
    private List<string> realPath;  // The path the player is supossed to take 
    Vector3 origP;

    private int nextSolutionTile;

    // Start is called before the first frame update
    void Start()
    {
        rat = GameObject.Find("Rat");

        //manager = FindObjectOfType<MinigameManager>();
        pathTaken = new List<string>();

        realPath = new List<string>{
            "4:1", 
            "4:2", "5:2", "6:2", "7:2", "8:2", "9:2",
            "9:3",
            "9:4", "8:4", "7:4", "6:4", "5:4",
            "5:5",
            "5:6", "6:6", "7:6", "8:6", "9:6",
            "9:7",
            "9:8", "8:8", "7:8", "6:8", "5:8", "4:8", "3:8",
            "3:7",
            "3:6", "2:6", "1:6",
            "1:7",
            "1:8",
            "1:9",
            "1:10"};
        nextSolutionTile = 0;

        origP = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Main function to edit path and game 
    private void OnCollisionEnter(Collision other){
        if (other.gameObject.CompareTag("Tile")){
            Transform parent = other.gameObject.transform.parent;

            if (parent != null){
                string [] first = parent.name.Split(" ");
                string [] second = other.gameObject.name.Split(" ");
                string tileName = first[1] + ":" + second[1];

                if (tileName == realPath[nextSolutionTile] && !pathTaken.Contains(tileName))
                {
                    pathTaken.Add(tileName);
                    Debug.Log(tileName);

                    other.gameObject.GetComponent<Renderer>().material.color = Color.green;
                    rat.GetComponent<AudioSource>().PlayOneShot(tilePressAudio);

                    nextSolutionTile++;
                }
                else if (!realPath.Contains(tileName))
                {
                    other.gameObject.GetComponent<Renderer>().material.color = Color.red;
                    revert();
                }

                //if (!pathTaken.Contains(tileName)){
                //    if (realPath.Length == 0 || realPath[pathTaken.Count].Equals(tileName) ){
                //        pathTaken.Add(tileName);
                //        Debug.Log(tileName);
                //    }
                //    else{
                //        revert();
                //    }
                //}
            }

            // load next area if puzzle is solved
            if (nextSolutionTile >= realPath.Count) {
                SceneManager.LoadScene("StartingArea2");
            }

            //if(other.gameObject.GetComponent<Renderer>().material.color != Color.green)
            //{
            //    other.gameObject.GetComponent<Renderer>().material.color = Color.green;
            //    manager.TileChecker();
            //}
        }
    }
    private void revert(){
        SceneManager.LoadScene("Minigame");

        //// revert each tile player previously went through back to normal
        //foreach (string tile in pathTaken){
        //    string [] names = tile.Split(":"); 

        //}


        //// reset puzzle counter
        //nextSolutionTile = 0;

        //// send player back to beginning
        //transform.position = origP; 
    }
}
