using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float runVelocity;
    public float jumpForce;
    Rigidbody2D rigidbody;
    //CheckGround checkGround;
    MarioStateManager marioStateManager;

    // Start is called before the first frame update
    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        //checkGround = GetComponent<CheckGround>();
        marioStateManager = GetComponent<MarioStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // while Mario is alived, the player can play 
        if(!MarioStateManager.marioIsDead)
        {
            // horizontal moving
            float horizontalMove = Input.GetAxis("Horizontal");
            Vector2 move = new Vector2(horizontalMove, 0f);
            transform.Translate(move * runVelocity * Time.deltaTime);
            marioStateManager.RunAnim(horizontalMove); // setting running animation

            // jumping
            if (Input.GetKeyDown(KeyCode.Space) && CheckGround.isInGround){
                rigidbody.AddForce(new Vector2(0, jumpForce));
            }
            marioStateManager.JumpAnim(CheckGround.isInGround); // setting jump animation
        }  
    }
}