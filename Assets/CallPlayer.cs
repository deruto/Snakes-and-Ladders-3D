using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPlayer : MonoBehaviour
{
    [SerializeReference] GameObject playerPrefab;
    public GameObject playerClone;
    [SerializeField] Snake snake;
    public bool playerSpawned;
    void Start()
    {
        SummonPlayer(transform.position);
    }

    public void SummonPlayer(Vector3 spawnPosition)
    {
        //creating an instance of the object
        playerClone = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (snake.teleportPlayer == true && playerSpawned == false)
        {
            Invoke("DelaySpawn", 2);
            playerSpawned = true;
        }
        
    }

    private void DelaySpawn()
    {
        SummonPlayer(snake.snakeEnd.transform.position);
    }
}
