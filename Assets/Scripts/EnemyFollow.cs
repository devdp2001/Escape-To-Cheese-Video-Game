using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

/// Created By: Dev Patel
/// Date:       10/23/2023
///     Base Implementation for the Attacking AI.
///     The enemy will move towards the player.

public class EnemyFollow : MonoBehaviour
{
    MinigameManager3 manager;
    public StealthAbility player;
    public NavMeshAgent Enemy;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<MinigameManager3>();
        Player = FindObjectOfType<NewInputManager>().gameObject.transform;
        player = FindObjectOfType<StealthAbility>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 6)
        {
            if(manager.godMode == true)
            {
                Debug.Log("God Scene Activated");
                return; //This will only be called during the 3rd minigame
            }
        }
        if(player.isStealth)
        {
            return;
        }
        Enemy.SetDestination(Player.position);
    }
}
