using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRoad : MonoBehaviour
{
    public Transform[] waypoints;
    void Awake() {
        waypoints = new Transform[transform.childCount];

        for (int i = 0; i < waypoints.Length; i++)
        {
           waypoints[i] = transform.GetChild(i);
        }
    }
}
