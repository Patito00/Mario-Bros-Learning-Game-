using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isInGround; 

    // if the player is in the ground
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Blocks") || other.gameObject.CompareTag("Floor")){
            isInGround = true;
        }    
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Blocks") || other.gameObject.CompareTag("Floor")){
            isInGround = true;
        } 
    }

    // if the player isn't
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Blocks") || other.gameObject.CompareTag("Floor")){
            isInGround = false;
        }    
    }
}
