using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingItem : MonoBehaviour
{
    public float speed; 
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Blocks"))
        {
            speed = -speed;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }    
    }   
}
