using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField] private GameObject LockedObjects;
    [SerializeField] private GameObject ToUnlockObjects;

    public void Unlocking() 
    {
        Debug.Log("Unlocking blocks");
        Destroy(LockedObjects);
        ToUnlockObjects.SetActive(true);
    }
}