using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Jumping variables
    public float jumpForce = 10;
    public float gravityModifier = 2.5f;
    private bool isOnFloor = true;
    [SerializeField] private Rigidbody playerRb;

    //Horizontal Movement variables
    private float horizontalInput;
    private bool lookingRight = true;
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private float speed = 10.0f;

    //Dashing variables
    private int dashDirection = 1;
    private Vector3 endPos;
    [SerializeField] private float dashDistance = 5;
    [SerializeField] float dashTime = 0.25f;
    [SerializeField] GameObject dashTrail;

    //Climbing to Roof variables
    private bool isOnLedge = false;
    public bool onRoof;
    
    
    void Awake()
    {
        // reset gravity
        Physics.gravity = new Vector3(0, -9.8f, 0);
        Physics.gravity *= gravityModifier;
    }
    // Start is called before the first frame update
    void Start()
    {
        dashTrail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetButtonDown("Jump") && isOnFloor) || (Input.GetButtonDown("Jump") && isOnLedge))
        {
           playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
           isOnFloor = false;
           isOnLedge = false;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        if (horizontalInput > 0)
        {
            TurnRight();
        }
        else if (horizontalInput < 0)
        {
            TurnLeft();
        }
        else
        {
         //   playerAnim.SetBool(IsWalking, false);
        }

        if (Input.GetButtonDown("Fire1") && isOnFloor)
        {
            DashMovement();
        }
        if (Input.GetButtonDown("Fire1") && isOnLedge)
        {
            ClimbtoRoof();
        }

    }
    void TurnRight()
    {
        lookingRight = true;
        playerMesh.transform.eulerAngles = new Vector3(playerMesh.transform.eulerAngles.x, 0, 0);
        dashDirection = 1;
        dashTrail.SetActive(false);
        //   playerAnim.SetBool(IsWalking, true);
    }

    void TurnLeft()
    {
        lookingRight = false;
        playerMesh.transform.eulerAngles = new Vector3(playerMesh.transform.eulerAngles.x, 180, 0);
        dashDirection = -1;
        dashTrail.SetActive(false);
        // playerAnim.SetBool(IsWalking, true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
            onRoof = false;
        }
        if (collision.gameObject.CompareTag("StairsLedge"))
        {
            isOnLedge = true;
            onRoof = false;
        }
        if (collision.gameObject.CompareTag("Roof"))
        {
            isOnLedge = false;
            isOnFloor = true;
        }
    }
    public void ClimbtoRoof()
    {
        transform.position = new Vector3(transform.position.x + 5, transform.position.y + 6, transform.position.z);
        onRoof = true;
    }
    void DashMovement()
    {
        dashTrail.SetActive(true);
        endPos = new Vector3(transform.position.x + dashDistance*dashDirection, transform.position.y, transform.position.z);
        StartCoroutine(LerpPosition(endPos,dashTime));
        
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {

        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition,targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
