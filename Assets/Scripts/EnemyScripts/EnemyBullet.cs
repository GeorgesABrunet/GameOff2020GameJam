using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float speed = 20f;
    private float lifeTime = 1.2f;
    private float distance = 0.5f;
    public LayerMask whatIsSolid;

    public int damage=5;

    void Update()
    {
        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("player rektd");
            }
            DestroyProjectile();
        }
        */
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform != this.transform )
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }/*
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    */
}
