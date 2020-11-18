using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnGameObjects;

    private void OnCollisionEnter2D(Collision2D other) {
     
        if(other.gameObject.CompareTag("Player"))
        {
            Animator blockAnimation = transform.parent.GetComponentInChildren<Animator>(); 
            if(!blockAnimation.GetBool("Unlock"))
            {
                blockAnimation.SetBool("Unlock", true);
                Vector2 spawnPosition = new Vector3(transform.position.x, 
                    transform.position.y + transform.parent.GetComponentInChildren<BoxCollider2D>().size.y);

                int spawnNumber = Random.Range(0, spawnGameObjects.Length);
                GameObject spawnObj = Instantiate(spawnGameObjects[spawnNumber], spawnPosition, Quaternion.identity);
                
                // if the spawn object was a coin wich gives you points
                if(spawnObj.CompareTag("Coin"))
                {
                    GameController.Instance.IncreasePoints(100);
                }
            }
        }
    }
}
