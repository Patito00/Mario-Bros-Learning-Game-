using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    GameController gameController;
    private void Start() {
        GameController gameController = GameController.Instance;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        Debug.Log("Collision");

        if(other.gameObject.CompareTag("Player")){
            gameController.points += 100;
            Debug.Log("Points: " + gameController.points);
            Destroy(gameObject);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        
        Debug.Log("Collision");

        if(collider.CompareTag("Player")){
            gameController.points += 100;
            Debug.Log("Points: " + gameController.points);
            Destroy(gameObject);
        }
    }
    */
}