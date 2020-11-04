using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 _movement;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float inputY = 0;
        float inputX = 0;

        //Vertical Movement
        if ( Input.GetKey(KeyCode.W) )
        inputY = 3;
        else if ( Input.GetKey(KeyCode.S) )
        inputY = -3;

        //Horizontal Movement
        if ( Input.GetKey(KeyCode.D) )
        {
            inputX = 3;
            transform.eulerAngles = new Vector2(0, 180);
        }
        else if ( Input.GetKey(KeyCode.A) )
        {
            inputX = -3;
            transform.eulerAngles = new Vector2(0, 0);
        }

        // Normalize
        _movement = new Vector2(inputX, inputY).normalized;

        //MOVEMENTS
        if (inputX == 0 && inputY == 0) 
        {
            anim.SetBool("IsWalk", false);
            rb.velocity = _movement * 0;
        }

        else
        {
            rb.velocity = _movement * speed;
            anim.SetBool("IsWalk", Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);
        }
    }
}