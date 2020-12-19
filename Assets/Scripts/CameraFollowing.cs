using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    private Vector3 osffet;
    private float targetXMoving;

    private void Start() {
        targetXMoving = target.position.x;    
        osffet = transform.position; 
    }

    // the camera follows the player when this one is advancing on the level
    void Update()
    {
        if(target != null)
        {
            transform.position = new Vector3(target.position.x, 0f, 0f) + osffet;
            /*if(target.position.x > targetXMoving)
            {
                transform.position = new Vector3(target.position.x, 0f, 0f) + osffet;
                targetXMoving = target.position.x;     
            }*/
        }
    }   
}