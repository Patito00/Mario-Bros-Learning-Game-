using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStateManager : MonoBehaviour
{   
    GameController gameController;
    public static bool marioIsDead;// { get; private set; }
    public float killJumpForce;
    public float deadJumpForce;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    SoundManager soundManager;

    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        soundManager = GetComponent<SoundManager>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        gameController = GameController.Instance;
    }
    private void Start() {
        marioIsDead = false;
    }

    // setting running animation
    public void RunAnim(float p_horizontalMove)
    {
        animator.SetBool("Running", (p_horizontalMove != 0f)); // changing anim
        if(p_horizontalMove < 0){
            spriteRenderer.flipX = true;
        }
        else if (p_horizontalMove > 0){
            spriteRenderer.flipX = false;
        }
    }
    // setting jumping animation
    public void JumpAnim(bool p_isInGround){
        animator.SetBool("IsInGround", p_isInGround);
    }
    // setting dead animation
    public void DeadAnim(){

        // setting variables
        animator.SetBool("Dead", true);
        rigidbody2D.AddForce(Vector2.up * deadJumpForce);
        boxCollider2D.enabled = false;  

        // playing the dead sound and changing scene
        marioIsDead = true;
        gameController.lives--;
        StartCoroutine(gameController.ChangingScene(soundManager.LoseALiveSound()));
    }   

    // setting killing JumpAnimation
    public void KillEnemyAnim()
    {
        rigidbody2D.AddForce(Vector2.up * killJumpForce);
    }
}
