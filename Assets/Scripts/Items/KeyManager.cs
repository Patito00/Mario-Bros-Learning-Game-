using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject LockedObjects;
    [SerializeField] private GameObject ToUnlockObjects;

    public void Unlocking()
    {
        ToUnlockObjects.SetActive(true);
        GameObject.Find("Sound Manager").GetComponent<SoundManager>().UnlockedKeySound();
        Destroy(LockedObjects);
        Destroy(gameObject);
    }
}