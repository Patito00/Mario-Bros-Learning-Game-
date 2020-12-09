using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithFlag : MonoBehaviour
{
    public GameObject winMarioAnimation;    
    MarioStateManager marioStateManager;

    private void Start() {
        marioStateManager = GetComponent<MarioStateManager>();
    }

    // when Mario collides with the pole
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.name == "Pole" && !MarioStateManager.completedLevel)
        {
            StartCoroutine(marioStateManager.CompletedLevel());
        }   
        else if(other.gameObject.CompareTag("Goal"))
        {
            GameObject marioInstantiated = Instantiate(winMarioAnimation, transform.position, Quaternion.identity);
            marioInstantiated.GetComponent<Animator>()
                .SetInteger("Mario Extra Lives", marioStateManager.marioExtraLives);
            marioInstantiated.GetComponent<Animator>().SetBool("Finish WaitingTime", true);
            Destroy(gameObject);    
        }
    }
}