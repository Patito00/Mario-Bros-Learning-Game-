using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItem : MonoBehaviour
{
    public float speed; 
    public float jumpForce;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2D;
    CheckGround checkGround;

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
            Debug.Log(checkGround.isInGround);
            if(checkGround.isInGround)
                rigidbody2D.AddForce(Vector3.up * jumpForce);
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