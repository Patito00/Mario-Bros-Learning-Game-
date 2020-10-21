using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioAnimationManager : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Animator animator;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
    public void JumpAnim(bool p_isInGround){
        animator.SetBool("IsInGround", p_isInGround);
    } 
}
