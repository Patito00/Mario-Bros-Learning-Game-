using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStateManager : MonoBehaviour
{   
    GameController gameController;
    public static bool marioIsDead;
    public float killJumpForce;
    public float deadJumpForce;
    public float starPowerTime;
    public int marioExtraLives { get; private set; }  
    private bool invincibility;
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
        marioExtraLives = 0;
    }

    // setting running animation
    public void RunningMario(float p_horizontalMove)
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
    public void JumpingMario(bool p_isInGround){
        animator.SetBool("IsInGround", p_isInGround);
    }

    // setting dead animation
    public void DeadMario(bool extraForce){
   
        if(!marioIsDead && !invincibility)
        {
            
            // setting variables
            animator.SetBool("Dead", true);
            rigidbody2D.AddForce(Vector2.up * deadJumpForce);
            boxCollider2D.enabled = false;  

            // playing the dead sound and changing scene
            marioIsDead = true;
            gameController.lives--;
            StartCoroutine(gameController.ChangingScene(soundManager.LoseALiveSound()));
        }
    }   
    // setting killing JumpAnimation
    public void KillEnemyAnim()
    {
        rigidbody2D.AddForce(Vector2.up * killJumpForce);
    }

    // Mario states methods
    public void ShrinkMario()
    {
        SetMarioExtraLive(0);
    }
    public void EnlargeMario()
    {
        if(marioExtraLives == 1)
        {
            gameController.IncreasePoints(100);
        }
        else
        {
            SetMarioExtraLive(1);
        }
    }
    public IEnumerator StarMario()
    {
        Debug.Log("StarMario");

        invincibility = true;
        animator.SetBool("Star", true);
        yield return new WaitForSeconds(starPowerTime);
        
        invincibility = false;
        animator.SetBool("Star", false);
    }

    // private methods and private corutines
    private void SetMarioExtraLive(int p_extraLives)
    {
        marioExtraLives = p_extraLives;
        animator.SetTrigger("Transform size");
        StartCoroutine(SetMarioState());
    }
    IEnumerator SetMarioState()
    {
        // both animations delays 1 second 
        yield return new WaitForSeconds(1f);

        // setting the correspond size layer
        invincibility = marioExtraLives == 0;
        animator.SetLayerWeight(marioExtraLives, 1); 
        animator.SetLayerWeight( invincibility ? 1 : 0, 0);

        // checking ghost State
        if (invincibility)
        {
            for (int i = 0; i < 6; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(.3f);
            }
            invincibility = false;
        }
    }
}