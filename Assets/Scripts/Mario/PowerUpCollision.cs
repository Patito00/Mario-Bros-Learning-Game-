using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            other.GetComponent<Animator>().SetBool("Picked Coin", true);
        }
    }
}