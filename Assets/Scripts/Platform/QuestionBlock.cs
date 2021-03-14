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

                /*int spawnNumber = Random.Range(0, spawnGameObjects.Length);*/
                int spawnNumber = Random.Range(0, 100);
                if (spawnNumber < 75) spawnNumber = 0;
                else if (spawnNumber > 75 && spawnNumber < 90) spawnNumber = 1;
                else spawnNumber = 2;
                
                GameObject spawnObj = new GameObject();
                try {
                    spawnObj = Instantiate(spawnGameObjects[spawnNumber], spawnPosition, Quaternion.identity);
                    if (spawnNumber == 2) Destroy(spawnObj, 10f);
                }
                catch {
                    spawnNumber--;
                    spawnObj = Instantiate(spawnGameObjects[spawnNumber], spawnPosition, Quaternion.identity);
                }

                // if the spawn object was a coin wich gives you points
                bool coinCollision = spawnObj.CompareTag("Coin"); 
                if(coinCollision) {
                    GameController.Instance.IncreasePoints(100);
                }
                GameObject.Find("Sound Manager").GetComponent<SoundManager>().QuestionBlockSound(!coinCollision);
            }
        }
    }
}
