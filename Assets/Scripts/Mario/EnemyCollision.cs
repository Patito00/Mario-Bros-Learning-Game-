using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private MarioStateManager stateManager;
    private CheckGround checkGround;


    private void Start() {
        stateManager = GetComponent<MarioStateManager>();
        checkGround = GetComponent<CheckGround>();
    }

    // checking if Mario collides with an enemy
    private void OnCollisionEnter2D(Collision2D other) {

        GameObject enemy = other.gameObject;

        // if Mario jumped over the enemy
        // Debug.Log(checkGround.isInGround);
        if( (!checkGround.IsGrounded() || stateManager.starMario)  && enemy.CompareTag("Enemy"))
        {
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            GameController.Instance.IncreasePoints(100);

            if(!stateManager.starMario)
                enemyAnimator.SetBool("Dead", true);        
            else
                Destroy(enemy); 

            stateManager.KillEnemy();
        }
        // if not check if Mario has an extra live to kill him or not
        else if(enemy.CompareTag("Enemy") || enemy.CompareTag("Trap"))
        {
            stateManager.DeadMario(false);
        }       
    }
}