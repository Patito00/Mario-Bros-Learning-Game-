using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithFlag : MonoBehaviour
{
    // when Mario collides with the pole
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.name == "Pole")
        {
            Debug.Log("Collision with pole");
        }   
        else if(other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Mario Win");
        }
    }
}