﻿using System.Collections;
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
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        marioStateManager = GetComponent<MarioStateManager>();
        checkGround = GetComponent<CheckGround>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if Mario dies, getting down away
        if (transform.position.y < deadPoint)
        {
            marioStateManager.DeadMario(true);
        }

        // else while Mario is alived, the player can play 
        else if (!MarioStateManager.marioIsDead && !MarioStateManager.completedLevel)
        {
            // horizontal moving
            float horizontalMove = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalMove * runVelocity * Time.deltaTime);
            marioStateManager.RunningMario(horizontalMove); // setting running animation

            // jumping
            if (checkGround.IsGrounded())
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    rigidbody.velocity = Vector2.up * jumpForce;
                }
            }
            marioStateManager.JumpingMario(checkGround.IsGrounded()); // setting jump animation
        }
    }
}