using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItem : MonoBehaviour
{
    public float speed; 
    public float jumpForce;
    private bool isInGround;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(isInGround)
        {
            rigidbody2D.AddForce(Vector3.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Platform"))
        {
            speed = -speed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        } 
        isInGround = other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor");   
    }  
    private void OnCollisionStay2D(Collision2D other) {
        isInGround = other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor");
    }
    private void OnCollisionExit2D(Collision2D other) {
        isInGround = !( other.gameObject.CompareTag("Platform") || other.gameObject.CompareTag("Floor") );
    }
    
    // how can I simplify the isInGround code?
}