using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    [Header("Belly")]
    public float MaxBelly = 100f;
    public float Belly = 0f;
    public float BellyRate = 0.02f;
    public Slider BellySlider;

    [Header("Hydration")]
    public float MaxHydration = 100f;
    public float Hydration = 0f;
    public float HydrationRate = 0.02f;
    public Slider HydrationSlider;

    [Header("Body Heat")]
    public float MaxHeat = 100f;
    public float Heat = 0f;
    //public Slider HeatSlider;

    [Header("Sanity")]
    public float MaxSanity = 100f;
    public float Sanity = 0f;
    //public Slider SanitySlider;


    // Start is called before the first frame update
    void Start()
    {
        Belly = MaxBelly;
        BellySlider.maxValue = MaxBelly;
        BellySlider.value = MaxBelly;
        
        Hydration = MaxHydration;

        HydrationSlider.maxValue = MaxHydration;
        HydrationSlider.value = MaxHydration;

        Heat = MaxHeat;
        Sanity = MaxSanity;

    }

    // Update is called once per frame
    void Update()
    {
        Hydration = Hydration - HydrationRate * Time.deltaTime;
        HydrationSlider.value = Hydration;

        Belly = Belly - BellyRate * Time.deltaTime;
        BellySlider.value = Belly;


    }
}
