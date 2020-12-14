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
        WinBar.SetActive(false);
        RecordText = WinBar.transform.GetChild(2).GetComponent<Text>();
        PointsText = PlayingBar.transform.GetChild(1).GetComponent<Text>();
        LivesText = PlayingBar.transform.GetChild(2).GetComponent<Text>();
        ChangeTexts();
    }

    // Start is called before the first frame update
    public static void ChangeTexts()
    {
        PointsText.text = "Points: " + GameController.Instance.points;
        LivesText.text = "Lives: " + GameController.Instance.lives;
        
        if(FinishLevel.finishedLevel)
        {
            RecordText.text = "Record: " + PlayerPrefs.GetInt("Record");
            PointsText.transform.GetComponentInParent<RectTransform>().anchoredPosition = Vector3.zero;
            RecordText.transform.GetComponentInParent<Transform>().gameObject.SetActive(true);
        }
    }
}
