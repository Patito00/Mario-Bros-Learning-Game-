using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KoopaStateManager : MonoBehaviour
{
    public float deadKoopaSpeed;
    Animator animator;
    EnemyMovement enemyMovement;
    EnemyMovement initial_enemyMovement;
    private bool isKoopaDead;
    private bool movingKoopa;

    private void Awake() {
        enemyMovement = GetComponent<EnemyMovement>();
        animator = GetComponent<Animator>();
    }
    private void Start() {
        initial_enemyMovement = enemyMovement;
        movingKoopa = false;
    }

    private void Update() {
        
        // if the koopa is dead
        if(animator.GetBool("Dead") && !isKoopaDead)
        {
            enemyMovement.noMoveLimits = true;
            enemyMovement.speed = deadKoopaSpeed;
            isKoopaDead = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(isKoopaDead)
        {
            switch(other.gameObject.tag)
            {
                // if collides with the player
                case "Player":
                    movingKoopa = !movingKoopa;
                    enemyMovement.enabled = movingKoopa;
                    break;

                // or with an enemy
                case "Enemy":
                    other.gameObject.GetComponent<Animator>().SetBool("Dead", true);
                    GameController.Instance.IncreasePoints(100);
                    // this is for the koopa can continue moving in the same direction
                    enemyMovement.speed = -enemyMovement.speed;   
                    break;
            }
        }
    }
}