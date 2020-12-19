using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    // private bool finishedLevel;
    
    // when Mario arrives in the castle
    public void ConquistCastle()
    {
        Transform flag = GameObject.Find("Castle Flag").transform;
        Transform flagStop = GameObject.Find("Castle Flag Stop").transform;
        flag.localPosition = flagStop.localPosition;
        StartCoroutine(ShowingFlagTime(1f));
    }

    private IEnumerator ShowingFlagTime(float showingTime)
    {
        yield return new WaitForSeconds(showingTime);
        GameObject.Find("Game Controller").GetComponent<LevelUIManager>().FinishLevelUI();
    }
}