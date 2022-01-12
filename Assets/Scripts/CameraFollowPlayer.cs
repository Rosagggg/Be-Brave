using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField] Vector3 offset = new Vector3(0, 3, -7);
    [SerializeField] Vector3 roofOffset = new Vector3(0, 5, 0);
    [SerializeField] GameObject player;
    private PlayerMove playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerScript.onRoof)
        {
            transform.position = new Vector3(player.transform.position.x, 0,player.transform.position.z) + offset + roofOffset;
        }
        else
        {
            transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z) + offset;
        }
        
    }
}
