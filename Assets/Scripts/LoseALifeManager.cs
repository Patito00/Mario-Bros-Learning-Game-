using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseALifeManager : MonoBehaviour
{
    public Text livesText; 

    // Start is called before the first frame update
    private void Start()
    {
        GameController gameController = GameController.Instance;
        livesText.text = gameController.lives + "x lives";   
        StartCoroutine(gameController.ChangingScene(0.9f));
    }
}