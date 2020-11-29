using UnityEngine;

public class OxygenStats : MonoBehaviour
{
    
    public int maxOxygenHealth = 300;
    public int currentOxygenHealth;
    public ShipBars OxygenBar;
    public GameObject YouDiedUI;
    public void Start()
    {
        currentOxygenHealth = maxOxygenHealth;
        OxygenBar.SetMaxHealth(maxOxygenHealth);
    }

    public void TakeDamage(int damage)
    {
        if (currentOxygenHealth > 0)
        {
            currentOxygenHealth -= damage;
            OxygenBar.SetOxygenHealth(currentOxygenHealth);
            Debug.Log("aw Engine's eating it dood");

        }
        
        if(currentOxygenHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("oh lawd Engine dieded");
        Time.timeScale = 0f;
        YouDiedUI.SetActive(true);
    }
}
