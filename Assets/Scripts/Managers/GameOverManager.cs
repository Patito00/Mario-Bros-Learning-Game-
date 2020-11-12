using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text pointsText;
    public Text recordText;
    private GameController gameController;

    private void Start() 
    {
        gameController = GameController.Instance;
        pointsText.text = "Points: " + gameController.points;
        recordText.text = "Record: " + PlayerPrefs.GetInt("Record");    
    }
    public void PlayAgain()
    {
        gameController.Restart();
        SceneManager.LoadScene("Level 1"); 
    }
}
