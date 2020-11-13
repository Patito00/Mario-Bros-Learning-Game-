using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemCollision : MonoBehaviour
{
    GameController gameController;
    MarioStateManager marioStateManager;

    private void Awake() {
        gameController = GameController.Instance;
        marioStateManager = GetComponent<MarioStateManager>();
    }

    // when Mario Collides with a pick item...
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Coin"))
        {
            other.GetComponent<Animator>().SetTrigger("Picked Coin");
            gameController.IncreasePoints(100);
        }
    }
    // ... or power up items
    private void OnCollisionEnter2D(Collision2D other) {
        switch(other.gameObject.tag)
        {
            case "Mushrooms":
                marioStateManager.EnlargeMario();
                Destroy(other.gameObject);
                break;

            case "Stars":
                StartCoroutine(marioStateManager.StarMario());
                Destroy(other.gameObject);
                break;
        }
    }
}