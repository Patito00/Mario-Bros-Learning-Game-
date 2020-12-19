using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    private static int currentLevel = 1;
    private static int totalLevels;
    private static readonly Lazy<GameController> lazy = new Lazy<GameController>(() => new GameController());
    public static GameController Instance { get { return lazy.Value; } }
    public int points { get; private set; }
    public int lives { get; private set; }
    private string currentScene;
    private string savedLevelScene;

    private void Awake() { totalLevels = SceneManager.sceneCountInBuildSettings - 2; }
    private GameController() 
    {
        points = 0;
        lives = 3;
    }

    // methods
    public void Restart()
    {   
        Instance.points = 0;
        Instance.lives = 3;
        SceneManager.LoadScene("Level 1");
    }
    public void NextLevel() 
    {
        currentLevel++;
        if(currentLevel < totalLevels) 
            SceneManager.LoadScene("Level " + currentLevel);
        else
            SceneManager.LoadScene("Final level");
    }

    public void IncreasePoints(int pointsToIncrease)
    {   
        points += pointsToIncrease;
        if(points > PlayerPrefs.GetInt("Record"))
        {
            PlayerPrefs.SetInt("Record", points);
        }
        GameObject.Find("Game Controller").GetComponent<LevelUIManager>().ChangeTexts();
    }

    // corotuines
    public IEnumerator ChangingScene(float secondsWait)
    {
        yield return new WaitForSeconds(secondsWait); // waiting seconds to change scene

        // changing scene
        currentScene = SceneManager.GetActiveScene().name;
        if(currentScene != "Lose a live scene")
        {
            lives--;
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