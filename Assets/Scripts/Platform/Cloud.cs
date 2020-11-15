using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float deadPosition;
    public float movingSpeed;


    // Update is called once per frame
    void Update()
    {
        if(transform.localPosition.x <= deadPosition)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.left * movingSpeed * Time.deltaTime);
        }
    }
}
