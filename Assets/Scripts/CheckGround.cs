using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool isInGround { get; private set; } 

    // if the object is in the ground
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
            isInGround = true;
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Platform"))
            isInGround = true;
    }

    // if the object isn't
    private void OnCollisionExit2D(Collision2D other) {
        isInGround = false;
    }
}