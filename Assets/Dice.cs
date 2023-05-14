using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] int rolledValue;
    public bool isDiceRolled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDiceRolled){
            RollTheDice();
        }
    }

    public int RollTheDice()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolledValue = Random.Range(1, 7);
            isDiceRolled = true;
        }
        return rolledValue;
    }
}
