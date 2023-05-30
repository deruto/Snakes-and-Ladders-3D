using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Dice dice;
    [SerializeField] PlayerMovement player;
    [SerializeField] MainRoad waypoint;
    [SerializeField] int p1CurrentIndex;
    [SerializeField] Vector3 p1Position;
    bool turnEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessWaypointIndex();
        if (!dice.isDiceRolled)
        {
            dice.RollTheDice();
        }
        if(p1CurrentIndex != 0){
            MovePlayer();
        }

    }

    private void MovePlayer()
    {
        player.ProcessMovement(waypoint.waypoints[p1CurrentIndex].transform.position);
    }

    private void ProcessWaypointIndex()
    {
        if(dice.RollTheDice()> 0 && !turnEnd){
            p1CurrentIndex = p1CurrentIndex + dice.RollTheDice();
            print(p1CurrentIndex);
            p1Position = waypoint.waypoints[p1CurrentIndex].transform.position;
            turnEnd = true;
        }
        
    }
}
