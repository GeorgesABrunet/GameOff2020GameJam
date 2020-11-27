using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenStorageDisplay : MonoBehaviour
{
    private TextMeshProUGUI ResourceDisplay;
    private PlayerStats stats;
    private float oxygenstored;

    void Start()
    {
        ResourceDisplay = GetComponent<TMPro.TextMeshProUGUI>();
        stats = FindObjectOfType<PlayerStats>();
        oxygenstored = stats.maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        oxygenstored = stats.oxygen;
        ResourceDisplay.text = "Oxygen: " + oxygenstored + " %";
    }
}
