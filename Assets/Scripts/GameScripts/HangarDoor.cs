using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarDoor : MonoBehaviour
{
    private Animator doorAnim;
    void Start()
    {
        doorAnim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("Open", true);
        }
    }

     void OnTriggerExit2D()
    {
        doorAnim.SetBool("Open", false);
    }
}
