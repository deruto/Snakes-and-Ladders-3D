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
    [SerializeField] int targetWaypointIndex;
    [SerializeField] Transform path;
    [SerializeField] Transform destination;
    [SerializeField] float speed;
    [SerializeField] float offsetDistance = 0.2f;
    [SerializeField] Dice diceNumber;
    [SerializeField] int diceValue;
    [SerializeField] int currentPosition;
    [SerializeField] bool turnEnd = false;
    [SerializeField] float resetSpeed;
    [SerializeField] bool destinationReached = false;
    Vector3 direction;
    bool ladderFound = false;
    bool gameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<MainRoad>();
        ladders = FindObjectOfType<Ladder>();
        diceNumber = FindObjectOfType<Dice>();
        path = target.waypoints[0];
        resetSpeed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        ResetValues();
        diceValue = diceNumber.RollTheDice();
        if(!turnEnd){
            targetWaypointIndex = currentPosition + diceValue;
        }
        StartTurn();
    }

    private void ResetValues()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            speed = resetSpeed;
            turnEnd = false;
        }
    }

    private void StartTurn()
    {
        if (diceValue == 6 || diceValue == 1 && gameStarted == false)
        {
            ProcessMovement();
            gameStarted = true;
        }
        else if (gameStarted == true && diceNumber.isDiceRolled)
        {
            ProcessMovement();
            
        }
        destinationReached = false;
    }

    private void ProcessMovement()
    {
        if(!turnEnd)
        {
            ProcessTargetNumber();
            direction = path.position - transform.position;
            transform.Translate(direction.normalized * speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, path.position) <= offsetDistance)
            {
                GetNextWaypoint();
            }
            ProcessDestination();
        }
    }

    private void ProcessTargetNumber()
    {
        if (diceNumber.isDiceRolled)
        {
            destination = target.waypoints[targetWaypointIndex];
        }
    }

    private void ProcessDestination()
    {
        if (Vector3.Distance(transform.position, destination.position) <= offsetDistance && !destinationReached)
        {
            ProcessTurnEnd();
        }
    }

    private void ProcessTurnEnd()
    {
        currentPosition = waypointIndex;
        turnEnd = true;
        destinationReached = true;
        if (turnEnd)
        {
            diceNumber.isDiceRolled = false;
        }
        if(destinationReached){
            targetWaypointIndex = 0;
            print(targetWaypointIndex);
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
