using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float runVelocity;
    public float jumpForce;
    Rigidbody2D rigidbody;
    CheckGround checkGround;
    MarioAnimationManager marioAnimationManager;

    // Start is called before the first frame update
    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        checkGround = GetComponent<CheckGround>();
        marioAnimationManager = GetComponent<MarioAnimationManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal moving
        float horizontalMove = Input.GetAxis("Horizontal");
        Vector2 move = new Vector2(horizontalMove, 0f);
        transform.Translate(move * runVelocity * Time.deltaTime);
        marioAnimationManager.RunAnim(horizontalMove); // setting running animation

        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && checkGround.isInGround){
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }
        marioAnimationManager.JumpAnim(checkGround.isInGround); // setting jump animation
    }
}
