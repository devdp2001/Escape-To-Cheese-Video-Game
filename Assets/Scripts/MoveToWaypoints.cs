using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// Created By: Dev Patel
/// Date:       10/23/2023
///     Implementation for the Patrolling AI.
///     The enemy will move through different waypoints.

public class MoveToWaypoints : MonoBehaviour
{
    public NavMeshAgent navMesh;
    private Animator anim;
    public GameObject[] waypoints;
    private int currWaypoint = 0;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        setNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if ((navMesh.remainingDistance <= .1f) && (!navMesh.pathPending))
        {
            setNextWaypoint();
        }
        //anim.SetFloat("Speed", navMesh.velocity.magnitude);
    }

    private void setNextWaypoint()
    {
        if (waypoints.Length == 0)
        {
            Debug.LogError("The waypoints[] has 0 length.");
        }

        currWaypoint++;
        if(currWaypoint >= waypoints.Length)
        {
           currWaypoint = 0;
        }

        navMesh.SetDestination(waypoints[currWaypoint].transform.position);
        //Debug.Log(waypoints.Length);
    }
}
