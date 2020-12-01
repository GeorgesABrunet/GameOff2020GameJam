using UnityEngine;
using TMPro;

public class TimerDisplay : MonoBehaviour
{
    private TextMeshProUGUI HeadsUp;
    private WaveSpawner Spawner;
    private float TimeTillEnemies;

    private int timer;
    

    public void Start()
    {
        HeadsUp = GetComponent<TMPro.TextMeshProUGUI>();
        Spawner = FindObjectOfType<WaveSpawner>();
        TimeTillEnemies = Spawner.waveCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        timer = (int) TimeTillEnemies;
        if (TimeTillEnemies <= 0.1)
        {
            TimeTillEnemies = 0;
            HeadsUp.text = "Hostiles have boarded the ship. Please destroy.";
        }

        if (Spawner.waveCountdown > 0)
        {
            TimeTillEnemies = Spawner.waveCountdown;
            HeadsUp.text = "Attention! Hostiles approaching in " + timer + " seconds.";
        }
    }
}
