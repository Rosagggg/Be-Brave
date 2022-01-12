using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground2 : MonoBehaviour
{
    public Vector3 startPos;
    public float repeatLength = 100;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
       // secondPos = secondBackground.GetComponent<RepeatBackground>().startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatLength*2)
        {
            transform.position = startPos;
        }
    }
}
