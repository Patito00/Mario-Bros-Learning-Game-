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
        CollideWithEnemy(other.gameObject);        
    }
    // private void OnCollisionStay2D(Collision2D other) {
    //     CollideWithEnemy(other.gameObject);
    // }

    private void CollideWithEnemy(GameObject enemy)
    {
        // if Mario can kill the enemy
        if(!CheckGround.isInGround && enemy.CompareTag("Enemy"))
        {
            enemy.GetComponent<Animator>().SetBool("Dead", true);
            gameController.IncreasePoints(100);
            stateManager.KillEnemyAnim(enemy);
        }

        // if not check if Mario has an extra live to kill him or not
        else if(enemy.CompareTag("Enemy") || enemy.CompareTag("Trap"))
        {
            stateManager.DeadMario(false);
            // if(stateManager.marioExtraLives > 0)
            //     stateManager.ShrinkMario();
                
            // else
            //     stateManager.DeadMario(false); 
        }
    }
}