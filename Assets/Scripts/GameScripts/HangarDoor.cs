using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HangarDoor : MonoBehaviour
{
    private Animator doorAnim;
    private AudioSource slidingDoor;

    public int maxDoorHealth = 300;
    public int currentDoorHealth;
    public GameObject destroyEffect;

    void Start()
    {
        doorAnim = GetComponent<Animator>();
        slidingDoor = GetComponent<AudioSource>();
        currentDoorHealth = maxDoorHealth;
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

    public void TakeDamage(int damage)
    {
        if (currentDoorHealth > 0)
        {
            currentDoorHealth -= damage;
            Debug.Log("aw Door's eating it dood");

        }
        
        if(currentDoorHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            var graphToScan = AstarPath.active.data.gridGraph;
            AstarPath.active.Scan(graphToScan);
        }
    }
}
