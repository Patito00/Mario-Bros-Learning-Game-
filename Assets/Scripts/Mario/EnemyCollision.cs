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
    private void OnCollisionStay2D(Collision2D other) {
        CollideWithEnemy(other.gameObject);
    }

    private void CollideWithEnemy(GameObject enemy) //, int pointsToIncrease)
    {
        bool isNotKillable = enemy.CompareTag("Trap"); 

        if(enemy.CompareTag("Enemy") || isNotKillable)
        {
            // if Mario can kill the enemy
            if(!CheckGround.isInGround && !isNotKillable)   
            {
                enemy.GetComponent<Animator>().SetBool("Dead", true);
                gameController.IncreasePoints(100);
                stateManager.KillEnemyAnim();
            }

            // if not check if Mario has an extra live to kill him or not
            else
            {
                if(stateManager.marioExtraLives > 0)
                    stateManager.ShrinkMario();
                    
                else
                    stateManager.DeadMario(false); 
            }
        } 
    }
}