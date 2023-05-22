using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] MainRoad path;
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
            yield return new WaitForSeconds(1f);
        }
    }
}
