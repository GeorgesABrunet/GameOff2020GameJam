using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform DamagePoint;
    public float attackRange = 0.8f;
    public LayerMask enemyLayers;
    private Animator anim;
    public int attackDamage = 10;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("IsStanding");

        //detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(DamagePoint.position, attackRange, enemyLayers);
        //damage
        foreach(Collider2D enemy in hitEnemies)
        {
        Debug.Log("Damaged" + enemy.name + ",");
        //enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        enemy.GetComponent<EngineStats>().TakeDamage(attackDamage);
        }
    }*/
}
