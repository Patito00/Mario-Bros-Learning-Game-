using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    [SerializeField] private float runVelocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private float deadPoint;

    Rigidbody2D rigidbody;
    MarioStateManager marioStateManager;
    CheckGround checkGround;

    // Start is called before the first frame update
    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        marioStateManager = GetComponent<MarioStateManager>();
        checkGround = GetComponent<CheckGround>();
    }

    // Update is called once per frame
    void Update()
    {
        // if Mario dies, getting down away
        if(transform.position.y < deadPoint)
        {
            marioStateManager.DeadMario(true);
        }

        // else while Mario is alived, the player can play 
        else if(!MarioStateManager.marioIsDead && !MarioStateManager.completedLevel)
        {
            // horizontal moving
            float horizontalMove = Input.GetAxis("Horizontal");
            Vector2 move = new Vector2(horizontalMove, 0f);
            transform.Translate(move * runVelocity * Time.deltaTime);  

            // rigidbody.velocity = move * runVelocity * Time.deltaTime;
            // interesante probar mover a Mario con el Rigidbody

            marioStateManager.RunningMario(horizontalMove); // setting running animation

            // jumping
            if (Input.GetKeyDown(KeyCode.Space) && checkGround.isInGround){
                // rigidbody.AddForce(new Vector2(0, jumpForce));
                rigidbody.velocity = Vector2.up * jumpForce;
            }
            marioStateManager.JumpingMario(checkGround.isInGround); // setting jump animation
        }  
    }
}