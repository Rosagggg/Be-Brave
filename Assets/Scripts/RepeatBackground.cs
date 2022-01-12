using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 secondPos;
    [SerializeField] GameObject secondBackground;
    private float repeatLength;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        secondPos = secondBackground.GetComponent<RepeatBackground2>().startPos;
        repeatLength = secondBackground.GetComponent<RepeatBackground2>().repeatLength;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatLength)
        {
            transform.position = secondPos;
        }
    }
}
