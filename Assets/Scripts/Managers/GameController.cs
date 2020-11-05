using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    private static readonly Lazy<GameController> lazy = new Lazy<GameController>(() => new GameController());
    public static GameController Instance { get { return lazy.Value; } }
    [NonSerialized] public int points;
    [NonSerialized] public int lives;
    [NonSerialized] public bool marioIsDead;
    private string currentScene;
    private string savedLevelScene;

    private GameController() {
        points = 0;
        lives = 3;
    }
    public void IncreasePoints(int pointsToIncrease)
    {
        points += pointsToIncrease;
        if(points > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", points);
        }
        Debug.Log("Points: " + points);
    }

    public IEnumerator ChangingScene(float secondsWait)
    {
        yield return new WaitForSeconds(secondsWait); // waiting seconds to change scene

        // changing scene
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene != "Lose a live scene")
        {
            if(lives > 0)
            {
                SceneManager.LoadScene("Lose a live scene"); 
                savedLevelScene = currentScene;
            }
            else
                SceneManager.LoadScene("Game Over scene");
        }
        else
        {
            SceneManager.LoadScene(savedLevelScene); 
        }
    }
}