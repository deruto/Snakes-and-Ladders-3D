using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeMouth;
    public GameObject snakeEnd;
    [SerializeField] bool playerEaten;
    [SerializeField] Transform playerObject;

    void Update() 
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player"){
            playerEaten = true;
            Destroy(playerObject);
            DigestPlayer();
        }
    }

    private void DigestPlayer()
    {
        if(playerEaten){
            Instantiate(playerObject.gameObject, snakeEnd.transform.position, Quaternion.identity);
            playerEaten = false;
        }
    }
}
