using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    GameController gameController;  
    private MarioStateManager stateManager;

    private void Start() {
        gameController = GameController.Instance;
        stateManager = GetComponent<MarioStateManager>();
    }
    private void OnCollisionEnter2D(Collision2D other) {

        bool isNotKillable = other.gameObject.CompareTag("Trap"); 

        if(other.gameObject.CompareTag("Enemy") || isNotKillable)
        {
            if(!CheckGround.isInGround && !isNotKillable)   
            {
                other.gameObject.GetComponent<Animator>().SetBool("Dead", true);
                gameController.IncreasePoints(100);
                stateManager.KillEnemyAnim();
            }
            else
            {
                stateManager.DeadAnim(); 
            }
        }
    }
}