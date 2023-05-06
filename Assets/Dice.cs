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
        RollTheDice();
    }

    public int RollTheDice()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rolledValue = Random.Range(1, 7);
            print(rolledValue);
            isDiceRolled = true;
        }
        return rolledValue;
    }
}
