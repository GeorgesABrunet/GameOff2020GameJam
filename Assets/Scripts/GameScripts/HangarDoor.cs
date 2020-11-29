using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangarDoor : MonoBehaviour
{
    private Animator doorAnim;
    private AudioSource slidingDoor;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
        slidingDoor = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnim.SetBool("Open", true);

            if (doorAnim.GetBool("Open"))
            {
                if (!slidingDoor.isPlaying)
                {
                    slidingDoor.Play();
                }
            }
            else
            {
                slidingDoor.Stop();
            }
        }
        else
        {
            doorAnim.SetBool("Open", false);
            slidingDoor.Stop();
        }
    }

     void OnTriggerExit2D()
    {
        doorAnim.SetBool("Open", false);
    }
}
