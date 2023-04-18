using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public Transform[] ladderWaypoints;

    void Awake()
    {
        ladderWaypoints = new Transform[transform.childCount];

        for (int i = 0; i < ladderWaypoints.Length; i++)
        {
            ladderWaypoints[i] = transform.GetChild(i);
        }
    }
}
