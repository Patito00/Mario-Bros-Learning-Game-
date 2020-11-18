using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithFlag : MonoBehaviour
{
    MarioStateManager marioStateManager;

    private void Start() {
        marioStateManager = GetComponent<MarioStateManager>();
    }

    // when Mario collides with the pole
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.name == "Pole" && !MarioStateManager.winMario)
        {
            StartCoroutine(marioStateManager.WinMario());
        }   
        else if(other.gameObject.CompareTag("Goal"))
        {
            Debug.Log("Mario Win");
        }
    }
}