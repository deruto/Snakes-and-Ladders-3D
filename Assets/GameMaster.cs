using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] Dice dice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!dice.isDiceRolled){
            dice.RollTheDice();
        }
        
    }
}
