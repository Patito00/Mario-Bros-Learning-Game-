using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    GameController gameController;  
    private MarioStateManager stateManager;
    private CheckGround checkGround;


    private void Start() {
        gameController = GameController.Instance;
        stateManager = GetComponent<MarioStateManager>();
        checkGround = GetComponent<CheckGround>();
    }

    // checking if Mario collides with an enemy
    private void OnCollisionEnter2D(Collision2D other) {

        GameObject enemy = other.gameObject;

        // if Mario jumped over the enemy
        if( !checkGround.isInGround && enemy.CompareTag("Enemy"))
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            gameController.IncreasePoints(!enemyAnimator.GetBool("Dead") ? 100 : 0);
            enemyAnimator.SetBool("Dead", true);
            stateManager.KillEnemyAnim(enemy);
        }
        // if not check if Mario has an extra live to kill him or not
        else if(enemy.CompareTag("Enemy") || enemy.CompareTag("Trap"))
        {
            stateManager.DeadMario(false);
        }       
    }
}