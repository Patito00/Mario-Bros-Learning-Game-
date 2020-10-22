using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameController gameController;  

    private void Start() {
        gameController = GameController.Instance;
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Player")){
            gameController.lifes--;
            Debug.Log("Enemy atacked");
            Debug.Log("Lifes: " + gameController.lifes);
        }
    }
}
