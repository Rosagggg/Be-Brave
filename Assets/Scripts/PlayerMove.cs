using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Jumping variables
    public float jumpForce = 10;
    public float gravityModifier = 2.5f;
    public bool isOnFloor = true;

    //Horizontal Movement variables
    private float horizontalInput;
    private bool lookingRight = true;
    [SerializeField] private float dashDistance = 5;
    private int dashDirection = 1;


    [SerializeField] private float speed = 10.0f;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject player;

    void Awake()
    {
        // reset gravity
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Physics.gravity *= gravityModifier;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
           playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           isOnFloor = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (horizontalInput < 0)
        {
            lookingRight = false;
            //   playerAnim.SetBool(IsWalking, true);
            TurnLeft();
        }
        else if (horizontalInput > 0)
        {
            lookingRight = true;
            //   playerAnim.SetBool(IsWalking, true);
            TurnRight();
        }
        else
        {
         //   playerAnim.SetBool(IsWalking, false);
        }

        if (Input.GetButtonDown("Fire1") && isOnFloor)
        {
            transform.position = new Vector3(transform.position.x + dashDistance *dashDirection, transform.position.y, transform.position.z);
        }

    }
    void TurnRight()
    {
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, 0);
        lookingRight = true;
        dashDirection = 1;
    }

    void TurnLeft()
    {
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 180, 0);
        lookingRight = false;
        dashDirection = -1;
    }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }
}
