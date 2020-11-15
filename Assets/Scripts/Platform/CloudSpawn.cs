using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject[] clouds;
    public float waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawningClouds());
    }

    IEnumerator SpawningClouds()
    {
        while(true)
        {
            GameObject cloud = Instantiate(clouds[Random.Range(0, clouds.Length)], transform.position, Quaternion.identity);
            cloud.transform.SetParent(transform.parent);
            yield return new WaitForSeconds(waitingTime);
        }
    }
}
