using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class created by Poot
*/
public class PlayerCombat : MonoBehaviour
{
   public AudioSource swingSound;
    public Collider2D SwordBox;
    public LayerMask enemyLayers;
    public Animator anim;
    private bool IsSwinging;
    public int attackDamage = 80;
    public float attackRate = 2f;
    float nextAttackTime = 1f;
    void Start()
    {
        swingSound = GetComponent<AudioSource>();
        SwordBox = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        IsSwinging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Attack();
            }
        }
    }
    void EnableAttack()
    {
        IsSwinging = true;
    }

    void DisableAttack()
    {
        IsSwinging = false;
    }
    void Attack()
    {
        //IsSwinging = true;
        swingSound.Play();
        anim.SetTrigger("IsSwing1");
        nextAttackTime = Time.time + 1f / attackRate;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsSwinging)
        {
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log("Get rektd bitch");
                other.GetComponent<EnemyHealth>().EnemyTakeDamage(attackDamage);
            }
        }
    }
}
