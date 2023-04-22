using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MainRoad target;
    [SerializeField] Ladder ladders;
    [SerializeField] int waypointIndex;
    [SerializeField] int ladderWaypointIndex;
    [SerializeField] Transform path;
    [SerializeField] float speed;
    [SerializeField] float offsetDistance = 0.2f;
    
    Vector3 direction;
    bool ladderFound = false;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<MainRoad>();
        ladders = FindObjectOfType<Ladder>();
        path = target.waypoints[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        direction = path.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, path.position) <= offsetDistance)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        waypointIndex++;
        path = target.waypoints[waypointIndex];
        if(ladderFound == true)
        {
            ladderWaypointIndex ++;
            path = ladders.ladderWaypoints[ladderWaypointIndex];
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Ladder")
        {
            ladderFound = true;
            waypointIndex = ladderWaypointIndex;
            path = ladders.ladderWaypoints[ladderWaypointIndex];
        }

        if(other.gameObject.tag == "LadderEnd")
        {
            ladderFound = false;
            ladderWaypointIndex = 0;
            waypointIndex = 0;
            path = target.waypoints[waypointIndex];
        }
    }

}
