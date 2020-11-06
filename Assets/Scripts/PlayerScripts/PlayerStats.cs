using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //slider rates for player stats
    [Header("Belly")]
    public float MaxBelly = 100f;
    public float Belly = 0f;
    public float BellyRate = 0.2f;
    public Slider BellySlider;

    [Header("Hydration")]
    public float MaxHydration = 100f;
    public float Hydration = 0f;
    public float HydrationRate = 0.2f;
    public Slider HydrationSlider;

    [Header("Body Heat")]
    public float MaxBodyHeat = 100f;
    public float BodyHeat = 0f;
    public float BodyHeatRate = 0.2f;
    public Slider BodyHeatSlider;

    [Header("Sanity")]
    public float MaxSanity = 100f;
    public float Sanity = 0f;
    public Slider SanitySlider;

    public PlayerMovement isPlayerMoving;

    // Start is called before the first frame update
    void Start()
    {
        //sets all the sliders to their max start values
        Belly = MaxBelly;
        BellySlider.maxValue = MaxBelly;
        BellySlider.value = MaxBelly;
        
        Hydration = MaxHydration;
        HydrationSlider.maxValue = MaxHydration;
        HydrationSlider.value = MaxHydration;

        BodyHeat = MaxBodyHeat;
        BodyHeatSlider.maxValue = MaxBodyHeat;
        BodyHeatSlider.value = MaxBodyHeat;

        Sanity = MaxSanity;
        SanitySlider.maxValue = MaxSanity;
        SanitySlider.value = MaxSanity;
        SanitySlider.value = MaxSanity;

        //finds the isMoving function form PlayerMovementScript to call on later
        isPlayerMoving = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //Constant Hydration rate and adjusting sliders appropriately- TODO: add positive increment for drinking water
        Hydration = Hydration - HydrationRate * Time.deltaTime;
        HydrationSlider.value = Hydration;


        //Constant Belly rate and adjusting sliders appropriately over time - TODO: add positive increment to belly values for eating food (fresh and space food)
        Belly = Belly - BellyRate * Time.deltaTime;
        BellySlider.value = Belly;

        //calls on isMoving function from PlayerMovement script to determine if player is moving
        //if player is moving, increases body heat till max
        //if player staying still, decreases body heat
        if (isPlayerMoving.isMoving() == false)
        {
            BodyHeat = BodyHeat - BodyHeatRate * Time.deltaTime;
            BodyHeatSlider.value = BodyHeat;
        }
        else if (isPlayerMoving.isMoving() == true && BodyHeat < MaxBodyHeat)
        {
            BodyHeat = BodyHeat + BodyHeatRate * Time.deltaTime;
            BodyHeatSlider.value = BodyHeat;
        }

    }
}
