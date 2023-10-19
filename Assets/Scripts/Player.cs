using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayers;

    private Vector3 _moveDirection;
    private bool isRunning;
    private bool isGrounded;

    private Rigidbody rb;
    private float depth;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.SetGameControls();
        isRunning = false;

        rb = GetComponent<Rigidbody>();
        depth = GetComponent<Collider>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * _moveDirection;
        CheckGround();

        if (_moveDirection.x != 0)
        {
            GetComponent<SpriteRenderer>().flipX = (_moveDirection.x < 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

    }

    public void SetMovementDirection(Vector3 currentDirection)
    {
        _moveDirection = currentDirection;
    }

    public void Run()
    {
        if (isRunning == false)
        {
            speed *= 2;
            isRunning = true;
        }
        else
        {
            speed /= 2;
            isRunning = false;
        }
    }

    public void Jump()
    {
     


    }

    /*     Debug.Log("space pressed");
         if (isGrounded)
         {
             Debug.Log("Jumperoonie");
             rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         } */


    private void CheckGround()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, depth, groundLayers);
        Debug.DrawRay(transform.position, Vector3.down * depth,
            Color.green, 0, false);
    }
}

