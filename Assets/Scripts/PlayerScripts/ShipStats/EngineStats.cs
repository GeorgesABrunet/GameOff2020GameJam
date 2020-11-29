using UnityEngine;

public class EngineStats : MonoBehaviour
{
    public int maxEngineHealth = 300;
    int currentEngineHealth;
    public ShipBars EngineBar;
    public GameObject YouDiedUI;
    void Start()
    {
        currentEngineHealth = maxEngineHealth;
        EngineBar.SetMaxHealth(maxEngineHealth);
    }

     public void TakeDamage(int damage)
    {
        if (currentEngineHealth > 0)
        {
            currentEngineHealth -= damage;
            EngineBar.SetEngineHealth(currentEngineHealth);
            Debug.Log("aw Engine's eating it dood");

        }
        
        if(currentEngineHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        YouDiedUI.SetActive(true);
        Debug.Log("oh lawd Engine dieded");
        Time.timeScale = 0f;
        
    }
}
