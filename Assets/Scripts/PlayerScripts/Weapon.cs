using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private float offset = 0f;
    public GameObject projectile;
    public Transform shotPoint;
    public AudioSource PewPew;

    private float timeShots;

    private float startTimeShots = 0.25f;
    public void Start()
    {
        PewPew = GetComponent<AudioSource>();
    }
    public void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PewPew.Play();

                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeShots = startTimeShots;
            }    
        }
        else   
        {
            PewPew.Stop();
            timeShots -= Time.deltaTime;
        }

        
    }
}
