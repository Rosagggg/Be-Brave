using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground2 : MonoBehaviour
{
    private Vector3 startPos;
    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - 200)
        {
            transform.position = startPos;
        }
    }
}
