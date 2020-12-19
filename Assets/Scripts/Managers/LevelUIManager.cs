using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [SerializeField] private GameObject PlayingBar;
    [SerializeField] private GameObject WinBar;
    private static Text RecordText;
    private static Text PointsText;
    private static Text LivesText;

    private void Start() 
    {
        RecordText = WinBar.transform.GetChild(2).GetComponent<Text>();
        PointsText = PlayingBar.transform.GetChild(1).GetComponent<Text>();
        LivesText = PlayingBar.transform.GetChild(2).GetComponent<Text>();
        ChangeTexts();
    }

    public void ChangeTexts()
    {
        GameController gameController = GameController.Instance;
        PointsText.text = "Points: " + gameController.points;
        LivesText.text = "Lives: " + gameController.lives;
    }

    public void FinishLevelUI() 
    {
        RecordText.text = "Record: " + PlayerPrefs.GetInt("Record");
        WinBar.SetActive(true);
        PlayingBar.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }
}
