using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] int rolledValue;
    public bool isDiceRolled = false;

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
