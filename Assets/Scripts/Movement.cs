using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float horizontalInput;
    public float jumpInput;

    [SerializeField] public float speed = 1f;

    [SerializeField] public float jumpSpeed = 1f;

    private bool onGround = false;
    //private Vector2 lookLeft, lookRight;

    // private float hMove;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        

        

        float hMove = horizontalInput * speed * Time.deltaTime;

        _rb.velocity = new Vector2(hMove, _rb.velocity.y);


        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // handle jumping
        jumpInput = Input.GetAxisRaw("Jump");

        // first check if we are on the ground

        if (onGround)
        {
            // did we press jump?
            if (jumpInput >= 1)
            {
                // set the y axis of our velocity vector to be the jump sped

                _rb.velocity = new Vector2(hMove, jumpSpeed);

                // since we are jumping we are not on the ground anymore
                onGround = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // did we colllide with our ground?
        if(collision.gameObject.name == "BG")
        {
            // yes! set our y-velocoity to 0 for sure

            _rb.velocity = new Vector2(_rb.velocity.x, 0);

            // set this to true so we know we are on the ground in our update 
            onGround = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // we've exited a collider, is it our ground?
        if (collision.gameObject.name == "BG")
        {
            // yes, we should definitely not be on the ground now
            onGround = false;

        }
    }
}


