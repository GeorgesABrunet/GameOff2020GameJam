using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class created by Poot
*/
public class Projectile : MonoBehaviour
{
    private float speed = 20f;
    private float lifeTime = 1.2f;
    private float distance = 0.5f;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    public int damage = 15;

    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    private void Update()
    {
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("enemy rektd");
                hitInfo.collider.SendMessage("EnemyTakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
            DestroyProjectile();   
        }
        
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform != this.transform)
        {
            other.SendMessage("EnemyTakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }*/
    
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
