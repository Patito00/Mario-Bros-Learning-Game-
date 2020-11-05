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

    // checking if Mario collides with an enemy
    private void OnCollisionEnter2D(Collision2D other) {

        bool isNotKillable = other.gameObject.CompareTag("Trap"); 

        if(other.gameObject.CompareTag("Enemy") || isNotKillable)
        {

            // if Mario can kill the enemy
            if(!CheckGround.isInGround && !isNotKillable)   
            {
                other.gameObject.GetComponent<Animator>().SetBool("Dead", true);
                gameController.IncreasePoints(100);
                stateManager.KillEnemyAnim();
            }

            // if not check if Mario has an extra live to kill him or not
            else
            {
                if(stateManager.marioExtraLives > 0)
                    stateManager.BigToSmallMario();
                    
                else
                    stateManager.DeadMario(false); 
            }
        }
    }
}