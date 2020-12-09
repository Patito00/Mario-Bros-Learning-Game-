using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioStateManager : MonoBehaviour
{   
    GameController gameController;
    public static bool marioIsDead;
    public static bool completedLevel;
    public bool starMario { get; private set; }
    public float killJumpForce;
    public float deadJumpForce;
    public float starPowerTime;
    public int marioExtraLives { get; private set; }  
    private bool ghostMario;
    Rigidbody2D rigidbody2D;
    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;
    Animator animator;
    SoundManager soundManager;

    private void Awake() 
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
        gameController = GameController.Instance;
    }
    private void Start() 
    {
        marioIsDead = false;
        completedLevel = false;
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
    public void JumpingMario(bool p_isInGround)
    {
        animator.SetBool("IsInGround", p_isInGround);
    }

    // setting dead animation
    public void DeadMario(bool deadByAltitude)
    {
   
        if(marioExtraLives > 0)
        {
            ShrinkMario();
        }
        else if(!marioIsDead && ( !(ghostMario || starMario) || deadByAltitude ))
        {
            // setting variables
            animator.SetBool("Dead", true);
            rigidbody2D.velocity = Vector2.up * deadJumpForce;
            // rigidbody2D.AddForce(Vector2.up * deadJumpForce, ForceMode2D.Impulse);
            boxCollider2D.enabled = false;  

            // playing the dead sound and changing scene
            marioIsDead = true;
            StartCoroutine(gameController.ChangingScene(soundManager.LoseALive()));
        }
    }   
    // setting killing JumpAnimation
    public void KillEnemyAnim()
    {
        if(!starMario)
        {
            rigidbody2D.velocity = Vector2.up * killJumpForce;
        }
        soundManager.KickEnemySound();
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
        starMario = true;
        animator.SetBool("Star", true);
        soundManager.Starman();
        yield return new WaitForSeconds(starPowerTime);
        
        starMario = false;
        // soundManager.PlayBackground();
        animator.SetBool("Star", false);
    }
    public IEnumerator CompletedLevel()
    {
        // Mario is quiet
        rigidbody2D.bodyType = RigidbodyType2D.Static;
        completedLevel = true;
        soundManager.FinishLevel();
        animator.SetBool("Mario Win Level", completedLevel);

        // Mario moves and then changing Music
        yield return new WaitForSeconds(1f);
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }

    // private methods and private corutines
    private void SetMarioExtraLive(int p_extraLives)
    {
        marioExtraLives = p_extraLives;
        animator.SetTrigger("Transform size");
        soundManager.MushroomSound(marioExtraLives==1);
        StartCoroutine(SetMarioState());
    }
    IEnumerator SetMarioState()
    {
        // both animations delays 1 second 
        yield return new WaitForSeconds(1f);

        // setting the correspond size layer
        ghostMario = marioExtraLives == 0;
        animator.SetLayerWeight(marioExtraLives, 1); 
        animator.SetLayerWeight( ghostMario ? 1 : 0, 0);

        // checking ghost State
        if (ghostMario)
        {
            for (int i = 0; i < 6; i++)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                yield return new WaitForSeconds(.3f);
            }
            ghostMario = false;
        }
    }
}