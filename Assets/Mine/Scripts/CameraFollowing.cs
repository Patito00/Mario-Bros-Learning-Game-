using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    public Transform target;
    private float targetXMoving;
    public Vector3 osffet;
    private void Start() {
        targetXMoving = target.position.x;    
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > targetXMoving){
            transform.position = new Vector3(target.position.x,
                transform.position.y, 0f) + osffet;

            targetXMoving = target.position.x;     
        }   
    }   
}
