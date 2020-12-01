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

    public bool IsBlocking;

    private int SwingType;
    public bool IsSwinging;
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
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("IsBlock", true);
        }

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                SwingType = Random.Range(1,6);
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
        anim.SetTrigger("IsSwing" + SwingType);
        if (SwingType == 6)
        {
            anim.SetTrigger("IsSwing1");
        }
        
        
        nextAttackTime = Time.time + 1f / attackRate;
    }

    void EnableBlock()
    {
        IsBlocking = true;
    }

    void DisableBlock()
    {
        IsBlocking = false;
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
