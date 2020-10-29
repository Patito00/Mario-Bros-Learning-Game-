﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool noMoveLimits;
    public float movingRange;
    public float speed;
    public SpriteRenderer spriteRenderer; // it's for flipping the enemy when its moving
    private float[] moveLimits;

    // when the scene started
    private void Start()
    {
        moveLimits = new float[]
        {
            transform.position.x + movingRange,
            transform.position.x - movingRange
        };
    }

    // Update is called once per frame
    void Update()
    {   
        // checking if the player lost
        if(!MarioStateManager.marioIsDead)
        {
            // checking limit moving
            if(!noMoveLimits && ( transform.position.x >= moveLimits[0] || transform.position.x <= moveLimits[1]) )
            {
                speed = -speed;
                if(spriteRenderer != null)
                    spriteRenderer.flipX = !spriteRenderer.flipX; 
                
            }  
            transform.Translate(Vector2.right * speed * Time.deltaTime); // moving the player
        }
        else
        {
            GetComponent<Animator>().speed = 0f;
        }
    }

    // the goomba changes the direction when collides with a block or an enemy
    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("Blocks") || other.gameObject.CompareTag("Enemy"))
        {
            speed = -speed;
            if(spriteRenderer != null)
                spriteRenderer.flipX = !spriteRenderer.flipX; 
        }
    }
}