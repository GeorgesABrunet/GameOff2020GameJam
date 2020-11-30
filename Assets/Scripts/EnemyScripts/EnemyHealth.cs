using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 200;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    public void EnemyTakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            //healthBar.SetHealth(currentHealth);
            //animator.SetTrigger("Hurt");
            Debug.Log("aw yea kill that m*ther f*ker");

        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Update is called once per frame
    void Die()
    {
        Destroy(gameObject);
    }
}
