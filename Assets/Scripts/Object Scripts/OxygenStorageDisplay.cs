using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OxygenStorageDisplay : MonoBehaviour
{
    private TextMeshProUGUI ResourceDisplay;
    public OxygenStats stats;
    public int oxygenStored;

    public void Start()
    {
        ResourceDisplay = GetComponent<TMPro.TextMeshProUGUI>();
        stats = FindObjectOfType<OxygenStats>();
        oxygenStored = stats.maxOxygenHealth;
    }

    // Update is called once per frame
    void Update()
    {
        oxygenStored = stats.currentOxygenHealth;
        ResourceDisplay.text = "Oxygen: " + oxygenStored;
    }
}
