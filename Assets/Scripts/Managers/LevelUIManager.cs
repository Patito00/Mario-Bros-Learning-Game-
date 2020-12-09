using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    public GameObject PlayingBar;
    public GameObject WinBar;
    private Text RecordText;
    private Text PointsText;
    private Text LivesText;

    private void Start() 
    {
        WinBar.SetActive(false);
        RecordText = WinBar.transform.GetChild(2).GetComponent<Text>();
        PointsText = PlayingBar.transform.GetChild(1).GetComponent<Text>();
        LivesText = PlayingBar.transform.GetChild(2).GetComponent<Text>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        PointsText.text = "Points: " + GameController.Instance.points;
        LivesText.text = "Lives: " + GameController.Instance.lives;
        
        if(FinishLevel.finishedLevel)
        {
            RecordText.text = "Record: " + PlayerPrefs.GetInt("Record");
            PlayingBar.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
            WinBar.SetActive(true);
        }
    }
}
