using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillSelf : MonoBehaviour
{
    GameController gameController;  
    Animator animator;

    private void Start() 
    {
        gameController = GameController.Instance;
        animator = GetComponent<Animator>();
    }
}
