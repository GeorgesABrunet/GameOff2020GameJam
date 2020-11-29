using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBarPlayer healthBar;

    public GameObject YouDiedUI;    
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            //animator.SetTrigger("Hurt");
            Debug.Log("aw no what is you doin baby");

        }
        
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("oh lawd you dieded");

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Time.timeScale = 0f;
        YouDiedUI.SetActive(true);
        
        //SceneManager.LoadScene("BarHub");
        
    }

}
