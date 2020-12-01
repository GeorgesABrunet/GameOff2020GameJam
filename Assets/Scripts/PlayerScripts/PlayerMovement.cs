using System;
using UnityEngine;

/*
    Class created by Poot
*/
public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;

    private float runSpeed = 8f;
    private Rigidbody2D rb;
    private Vector2 _movement;
    private Animator anim;

    //private AudioSource footStep;

    private bool BoiIsStanding;
    private void Start()
    {
        BoiIsStanding = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //footStep = GetComponent<AudioSource>();
    }

    private void Update()
    {
        float inputY = 0;
        float inputX = 0;

        //Vertical Movement
        if (BoiIsStanding == true)
        {
            if ( Input.GetKey(KeyCode.W) )
            {
                inputY = 3;
            }    
            else if ( Input.GetKey(KeyCode.S) )
            {
                inputY = -3;
            }
                

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
        }

        // Normalize
        _movement = new Vector2(inputX, inputY).normalized;

        //MOVEMENTS
        if (inputX == 0 && inputY == 0) 
        {
            anim.SetBool("IsWalk", false);
            anim.SetBool("IsRun", false);
            rb.velocity = _movement * 0;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.velocity = _movement * runSpeed;
                anim.SetBool("IsRun", true);
            }
            else
            {
                anim.SetBool("IsRun", false);
                rb.velocity = _movement * speed;
                //anim.SetBool("IsWalk", Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);
            }
            anim.SetBool("IsWalk", Math.Abs(_movement.sqrMagnitude) > Mathf.Epsilon);  
        }
        //MOVEMENT SOUNDS
        /*if (anim.GetBool("IsWalk"))
        {
            if (!footStep.isPlaying)
            {
                footStep.Play();
            }
        }
        else
        {
            footStep.Stop();
        }*/

        //ACTIONS

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (BoiIsStanding == true)
            {
                BoiIsStanding = false;
                anim.SetTrigger("IsSitting");
                Sit();
            }
            else
            {
                BoiIsStanding = true;
                StandUp();
            }
        }
    }

    private void Sit()
    {
        anim.SetBool("IsSit", true);
    }

    private void StandUp()
    {
        anim.SetBool("IsSit", false);
        anim.SetTrigger("IsStanding");
    }

    public bool isMoving()
    {
        if (anim.GetBool("IsWalk"))
        {
            return true;
        }
        else return false;
    }

}