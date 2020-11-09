using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public bool inRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    //checks for button and inRange of object to interact with
    //if passes check then invokes the event tied to the object
    void Update()
    {
        if(Input.GetButtonDown("Interact") && inRange)
        {
            interactAction.Invoke();
        }
    }


    //function to check if player is in range of object's collider
    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log ("Player in range of obj");
        }
    }


    //checks if player no longer in range of obejct's collider
    void OnTriggerExit2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log ("Player no longer in range of obj");
        }
    }
}
