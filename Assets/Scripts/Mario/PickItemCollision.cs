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
                other.GetComponent<Animator>().SetBool("Picked Coin", true);
                gameController.IncreasePoints(100);
                break;

            case "Mushrooms":
                marioStateManager.SmallToBigMario();
                Destroy(other.gameObject);
                break;

            case "Stars":
                Debug.Log("Stars");
                break;
        } 
    }
}