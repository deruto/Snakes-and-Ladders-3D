using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] MainRoad target;
    [SerializeField] int waypointIndex;
    [SerializeField] Transform path;
    [SerializeField] float speed;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        path = target.waypoints[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = path.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, path.position) <= 0.2f){
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        waypointIndex++;
        path = target.waypoints[waypointIndex];
    }
}
