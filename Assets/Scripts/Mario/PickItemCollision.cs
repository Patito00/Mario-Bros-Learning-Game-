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

    // when Mario Collides with a pick item
    private void OnTriggerEnter2D(Collider2D other) 
    {
        switch(other.tag)
        {
            case "Coin":
                other.GetComponent<Animator>().SetTrigger("Picked Coin");
                gameController.IncreasePoints(100);
                break;

            case "Mushrooms":
                marioStateManager.EnlargeMario();
                Destroy(other.gameObject);
                break;

            case "Stars":
                Debug.Log("Stars");
                break;
        } 
    }
    
    // private void OnCollisionEnter2D(Collision2D other) {
    //     switch(other.gameObject.tag)
    //     {
    //         case "Coin":
    //             other.gameObject.GetComponent<Animator>().SetTrigger("Picked Coin");
    //             gameController.IncreasePoints(100);
    //             break;

    //         case "Mushrooms":
    //             marioStateManager.EnlargeMario();
    //             Destroy(other.gameObject);
    //             break;

    //         case "Stars":
    //             Debug.Log("Stars");
    //             break;
    //     }
    // }
}