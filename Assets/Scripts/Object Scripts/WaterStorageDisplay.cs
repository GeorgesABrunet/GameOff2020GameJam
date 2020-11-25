using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaterStorageDisplay : MonoBehaviour
{
    private TextMeshProUGUI ResourceDisplay;
    private PlayerStats stats;
    private float waterstored;

    void Start()
    {
        ResourceDisplay = GetComponent<TMPro.TextMeshProUGUI>();
        //waterstored = stats.maxWater;
        stats = FindObjectOfType<PlayerStats>();
        waterstored = stats.maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        waterstored = stats.water;
        ResourceDisplay.text = waterstored + " %";
    }
}
