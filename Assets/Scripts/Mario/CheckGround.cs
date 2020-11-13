using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isInGround; 


    // if the player is in the ground
    private void OnCollisionEnter2D(Collision2D other) {
        isInGround = other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor");
    }
    private void OnCollisionStay2D(Collision2D other) {
        isInGround = other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor");
    }

    // if the player isn't
    private void OnCollisionExit2D(Collision2D other) {
        isInGround = !( other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor") );    
    }
}