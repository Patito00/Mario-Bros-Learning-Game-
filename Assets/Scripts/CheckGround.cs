using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private void Start() 
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public bool IsGrounded() 
    {
        float hitCollisionHeight = .1f;
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,
            0f, Vector2.down, hitCollisionHeight, LayerMask.GetMask("Platform"));
           
        bool isHitted = hit.collider != null;
        return isHitted;
    }
    // not working again //
}