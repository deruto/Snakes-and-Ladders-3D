using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MainRoad path;
    [SerializeField] int currentPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }
    // Update is called once per frame
    IEnumerator FollowPath(){
        foreach (Transform waypoint in path.waypoints)
        {
            transform.position = waypoint.position;
            currentPosition++;
            print(currentPosition);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
