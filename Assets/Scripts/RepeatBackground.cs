using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 secondPos;

    void Awake()
    {
        startPos = transform.position;
        secondPos = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - 100)
        {
            transform.position = secondPos;
        }
    }
}
