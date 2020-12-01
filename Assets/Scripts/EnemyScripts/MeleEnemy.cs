using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemy : EnemyFollow
{
    public Collider2D SwordBox;

    public int damage = 5;

    protected override void Attack()
    {
        base.Attack();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Destructable")
        {
            collision.SendMessage("EnemyTakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Debug.Log("Get rektd bitch");
        }
    }
}
