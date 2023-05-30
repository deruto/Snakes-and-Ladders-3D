using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MainRoad path;
    [SerializeField] int currentPosition;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    void Update()
    {

    }

    public void ProcessMovement(Vector3 endPosition)
    {
        transform.Translate(0, 0, 1 * Time.deltaTime);
        if (transform.position.z >= endPosition.z)
        {
            transform.position = endPosition;
        }
    }
}
