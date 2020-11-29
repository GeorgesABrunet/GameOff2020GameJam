using UnityEngine;

public class PowerStats : MonoBehaviour
{
    
    public int maxPowerHealth = 300;
    int currentPowerHealth;
    public ShipBars PowerBar;
    public GameObject YouDiedUI;
    void Start()
    {
        currentPowerHealth = maxPowerHealth;
        PowerBar.SetMaxHealth(maxPowerHealth);
    }

     public void TakeDamage(int damage)
    {
        if (currentPowerHealth > 0)
        {
            currentPowerHealth -= damage;
            PowerBar.SetPowerHealth(currentPowerHealth);
            Debug.Log("aw Power's eating it dood");

        }
        
        if(currentPowerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("oh lawd Power dieded");
        Time.timeScale = 0f;
        YouDiedUI.SetActive(true);
    }
}
