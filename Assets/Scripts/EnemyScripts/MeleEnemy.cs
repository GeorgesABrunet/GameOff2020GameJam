﻿using System;
using System.Collections;
using UnityEngine;

public class MeleEnemy : EnemyFollow
{
    //public Collider2D axeBox;
    public PlayerCombat BlockPos;
    public bool enemySwinging;
    public int enemySwingdamage = 12;
    private int ClobberingTime;

    public void EnemyEnableAttack()
    {
        enemySwinging = true;
    }

    public void EnemyDisableAttack()
    {
        enemySwinging = false;
    }
    protected override void Attack()
    {
        //base.Attack();
        base.enemyAnim.SetBool("IsWalk", true);

        ClobberingTime = UnityEngine.Random.Range(1,5);
        base.enemyAnim.SetTrigger("IsSwing"+ClobberingTime);
        if (ClobberingTime == 5)
        {
            base.enemyAnim.SetTrigger("IsSwing1");
        }/*
        else if (ClobberingTime == 2)
        {
            base.enemyAnim.SetTrigger("IsSwing2");
        }
        else if (ClobberingTime == 3)
        {
            base.enemyAnim.SetTrigger("IsSwing3");
        }
        else
        {
            base.enemyAnim.SetTrigger("IsSwing4");
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (enemySwinging)
        {
            if (other.gameObject.tag == "Player")
            {
                if (BlockPos.IsBlocking == false)
                {
                    Debug.Log("Eat dick bitch");
                    other.GetComponent<PlayerHealth>().TakeDamage(enemySwingdamage);
                }
            } 
                
            if (other.gameObject.tag == "Destructable")
            {
                Debug.Log("Get rektd, you hunko metal");
                other.SendMessage("TakeDamage", enemySwingdamage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
