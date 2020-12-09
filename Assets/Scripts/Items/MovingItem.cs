using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItem : MonoBehaviour
{
    public float speed; 
    public float jumpForce;
    private bool canJump;
    
    SpriteRenderer spriteRenderer;
    CheckGround checkGround;
    Rigidbody2D rigidbody2D;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(GetComponent<CheckGround>() != null)
        {
            checkGround = GetComponent<CheckGround>();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        // while the level hasn't finished, the items exist
        if(MarioStateManager.completedLevel || MarioStateManager.marioIsDead)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if(checkGround != null) 
            {
                Debug.Log(checkGround.isInGround);
                if(checkGround.isInGround) rigidbody2D.velocity = Vector2.up * jumpForce;
                // rigidbody2D.AddForce(checkGround.isInGround ? Vector2.up * jumpForce : Vector2.zero);
                // rigidbody2D.velocity = new Vector2(0, checkGround.isInGround ? jumpForce : -jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Platform"))
        {
            speed = -speed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        } 
    }  
}