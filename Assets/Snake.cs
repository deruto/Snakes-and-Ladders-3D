using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject snakeMouth;
    public GameObject snakeEnd;
    [SerializeField] bool playerEaten;
    public bool teleportPlayer;
    [SerializeField] CallPlayer callPlayer;

    [SerializeField] GameObject playerCloneHolder;

    void Update() 
    {
        FindPlayerClone();
    }

    private void FindPlayerClone()
    {
        playerCloneHolder = FindObjectOfType<CallPlayer>().playerClone;
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player"){
            playerEaten = true;
            DigestPlayer();
        }
    }

    private void DigestPlayer()
    {
        if(playerEaten){
            Destroy(playerCloneHolder);
            teleportPlayer = true;
            callPlayer.playerSpawned = false;
        }
        
    }
}
