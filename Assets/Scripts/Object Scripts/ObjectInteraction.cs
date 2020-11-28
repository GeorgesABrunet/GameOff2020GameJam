using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectInteraction : MonoBehaviour
{
    public bool inRange;

    public GameObject guiInteract;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    public AudioClip soundEffect;

    //checks for button and inRange of object to interact with
    //if passes check then invokes the event tied to the object
    void Start()
    {
        guiInteract.SetActive(false);
    }
    void Update()
    {
        if (inRange == true)
        {
            guiInteract.SetActive(true);
        }
        else if(inRange == false)
        {
            guiInteract.SetActive(false);
        }

        if(inRange && Input.GetButtonDown("Interact"))
        {
            interactAction.Invoke();
            if (soundEffect != null)
            {
                AudioSource.PlayClipAtPoint(soundEffect, transform.position);
            }
        }
    }


    //function to check if player is in range of object's collider
    private void OnTriggerEnter2D(Collider2D collisionObject)
    {
        if (collisionObject.gameObject.CompareTag("Player"))
        {
            //guiInteract.SetActive(true);
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
            //guiInteract.SetActive(false);
            Debug.Log ("Player no longer in range of obj");
        }
    }
}
