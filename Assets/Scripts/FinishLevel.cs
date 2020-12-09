using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public static bool finishedLevel;
    public static void FinishedLevelSetter(bool value){ finishedLevel = value; }
    
    private void Start() 
    {
        finishedLevel = false;
    }

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
        finishedLevel = true;
    }
}