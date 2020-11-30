using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class created by Poot
*/
public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public AudioSource PewPew;
    private float timeShots;
    private float startTimeShots = 0.1f;

    public void Start()
    {
        PewPew = GetComponent<AudioSource>();
    }
    public void Update()
    {
        FaceMouse();

        if (timeShots <= 0)
        {
            if (Input.GetKey(KeyCode.Mouse0))
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
    void FaceMouse()
    {
        Vector3 lookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (lookDirection.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, (180-angle));
        }
    }
}
