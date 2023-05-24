using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] MainRoad path;
    [SerializeField] int currentPosition;
    [SerializeField] Vector3 endPosition;
    // Start is called before the first frame update
    void Start()
    {
        endPosition = new Vector3(0, 0, 2);
    }

    void Update(){
        transform.Translate(0,0,1 * Time.deltaTime);
        if(transform.position.z >= endPosition.z){
            transform.position = endPosition;
        }
    }
}
