using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStateManager : MonoBehaviour
{   
    GameController gameController;
    public static bool marioIsDead;
    public float killJumpForce;
    public float deadJumpForce;
    public float extraDeadJumpForce;
    public bool isTransformingSize { get; private set; }
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
            animator.SetBool("Dead", true);
            
            // setting variables
            deadJumpForce += extraForce ? extraDeadJumpForce : 0; 
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

    // setting bigger, or litler, Mario state
    public void SmallToBigMario()
    {
        if(marioExtraLives < 1)
        {
            animator.SetTrigger("Transform size");
            marioExtraLives = 1;
        }
        else
            gameController.IncreasePoints(100);

        SetCurrentLayer(marioExtraLives);
    }
    public void BigToSmallMario()
    {
        animator.SetTrigger("Transform size");
        marioExtraLives = 0;
        // invincibility = true;
        SetCurrentLayer(marioExtraLives);
    }

    // invecibility state method 
    public void GhostState()
    {
        Debug.Log("Invoke Ghost State");
        StartCoroutine(GhostAnim(5, .33f));
    }
    // not working //


    // private methods and corutines
    private void SetCurrentLayer(int p_index)
    {
        for(int i = 0; i < animator.layerCount; i++)
        {
            string layer_name = animator.GetLayerName(i);

            if(i == p_index)
                animator.SetLayerWeight(p_index, 1);
            else
                animator.SetLayerWeight(i, 0);
        }
    }
    private IEnumerator GhostAnim(int repeat, float waitTime)
    {   
        for(int i = 0; i < repeat; i++)
        {
            Debug.Log("Mario " + ( (i % 2 == 0) ? "Appear" : "Disappear") );
            yield return new WaitForSeconds(waitTime);
        }
        invincibility = false;
        SetCurrentLayer(0);
    }
}