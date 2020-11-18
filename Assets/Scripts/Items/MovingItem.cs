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
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(checkGround != null) 
        {
            rigidbody2D.AddForce(checkGround.isInGround ? Vector3.up * jumpForce : Vector3.zero);
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