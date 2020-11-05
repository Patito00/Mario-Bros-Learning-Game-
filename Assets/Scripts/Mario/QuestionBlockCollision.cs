using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlockCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.CompareTag("Question Blocks"))
        {
            Debug.Log("Question Block collision."); 
            other.transform.parent.GetComponentInChildren<Animator>().SetBool("Unlocked", true);
        }
    }
}