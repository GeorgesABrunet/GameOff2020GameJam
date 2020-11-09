using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //slider rates for player stats
    [Header("Belly")]
    public float maxBelly = 100f;
    public float belly = 0f;
    public float bellyRate = 0.2f;
    public Slider bellySlider;

    [Header("Hydration")]
    public float maxHydration = 100f;
    public float hydration = 0f;
    public float hydrationRate = 0.2f;
    public Slider hydrationSlider;

    [Header("Body Heat")]
    public float maxBodyHeat = 100f;
    public float bodyHeat = 0f;
    public float bodyHeatRate = 0.2f;
    public Slider bodyHeatSlider;

    [Header("Sanity")]
    public float maxSanity = 100f;
    public float sanity = 0f;
    public float sanityRate = 0.2f;
    public Slider sanitySlider;

    //slider rates for ship resources
    [Header("O2")]
    public float maxOxygen = 100f;
    public float oxygen = 0f;
    public float oxygenRate = 0.5f;
    public Slider oxygenSlider;

    [Header("Fuel")]
    public float maxFuel = 100f;
    public float fuel = 0f;
    public Slider fuelSlider;

    [Header("Power")]
    public float maxPower = 100f;
    public float power = 0f;
    public Slider powerSlider;

    [Header("Water")]
    public int maxWater = 100;
    public int water = 0;
    public Slider waterSlider;

    [Header("Plants")]
    public int maxPlants = 10;
    public int plants = 0;
    public Slider plantSlider;

    public PlayerMovement isPlayerMoving;


    // Start is called before the first frame update
    void Start()
    {
        //sets all the sliders to their max start values
        belly = maxBelly;
        bellySlider.maxValue = maxBelly;
        bellySlider.value = maxBelly;
        
        hydration = maxHydration;
        hydrationSlider.maxValue = maxHydration;
        hydrationSlider.value = maxHydration;

        bodyHeat = maxBodyHeat;
        bodyHeatSlider.maxValue = maxBodyHeat;
        bodyHeatSlider.value = maxBodyHeat;

        sanity = maxSanity;
        sanitySlider.maxValue = maxSanity;
        sanitySlider.value = maxSanity;

        oxygen = maxOxygen;
        oxygenSlider.maxValue = maxOxygen;
        oxygenSlider.value = maxOxygen;

        fuel = maxFuel;
        fuelSlider.maxValue = maxFuel;
        fuelSlider.value = maxFuel;

        power = maxPower;
        powerSlider.maxValue = maxPower;
        powerSlider.value = maxPower;

        water = maxWater;
        waterSlider.maxValue = maxWater;
        waterSlider.value = maxWater;

        plants = maxPlants;
        plantSlider.maxValue = maxPlants;
        plantSlider.value = maxPlants;

        //finds the isMoving function form PlayerMovementScript to call on later
        isPlayerMoving = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        //Constant Hydration rate and adjusting sliders appropriately- TODO: add positive increment for drinking water
        hydration = hydration - hydrationRate * Time.deltaTime;
        hydrationSlider.value = hydration;


        //Constant Belly rate and adjusting sliders appropriately over time - TODO: add positive increment to belly values for eating food (fresh and space food)
        belly = belly - bellyRate * Time.deltaTime;
        bellySlider.value = belly;

        //calls on isMoving function from PlayerMovement script to determine if player is moving
        //if player is moving, increases body heat till max
        //if player staying still, decreases body heat
        if (isPlayerMoving.isMoving() == false)
        {
            bodyHeat = bodyHeat - bodyHeatRate * Time.deltaTime;
            bodyHeatSlider.value = bodyHeat;
            sanity = sanity - sanityRate * Time.deltaTime;
            sanitySlider.value = sanity;
        }
        else if (isPlayerMoving.isMoving() == true && bodyHeat < maxBodyHeat)
        {
            bodyHeat = bodyHeat + bodyHeatRate * Time.deltaTime;
            bodyHeatSlider.value = bodyHeat;
        }

        //water sliders adjusted to water amount
        waterSlider.value = water;


        //Plant sliders adjusted to plant amount
        plantSlider.value = plants;

        //fuel sliders adjusted to fuel amount
        fuelSlider.value = fuel;

        //O2 slider adjusted to O2 amount
        //creates new consumption or production rate of oxygen based on amount of plants
        oxygenSlider.value = oxygen;
        if (plants > 8)
        {
            oxygenRate = -0.2f;
        }
        else if (plants < 5)
        {
            oxygenRate = 0.5f * plants;
        }
        else
        {
            oxygenRate = 0;
        }
        if (oxygen > 0 && oxygenRate > 0 || oxygen < 100 && oxygenRate <= 0)
        {
            oxygen = oxygen - oxygenRate * Time.deltaTime;
            oxygenSlider.value = oxygen;
        }
        
        

        //power slider adjusted to power amount
        //powerSlider.value = power;
    }

    //function for event of eating processed food
    //called upon from object's event system
    //increases belly by 10 up to a max of 100 and decreases Hydation by 5
    public void eatProcessedFood()
    {
        if (belly < 90)
        {
            belly = belly + 10;
        }
        else if(belly > 90 && belly < 100)
        {
            belly = maxBelly;
        }
        hydration = hydration - 5;
        plants = plants - 2;
    }

    //function for event of drinking water
    //called upon from object's event system
    //increases hydration by 10 (TODO: add water as resource)
    public void drinkWater()
    {
        if (hydration < 90)
        {
            hydration = hydration + 10;
        }
        else if(hydration > 90 && hydration < 100)
        {
            hydration = maxHydration;
        }

        bodyHeat = bodyHeat - 10;
        water = water - 10;
    }

    public void tendGarden()
    {
        if( plants < 10 )
        {
            plants = plants + 1;
            water = water - 10;
            if (sanity < 90)
            {
                sanity = sanity + 10;
            }
            else if (sanity > 90 && sanity < 100)
            {
                sanity = maxSanity;
            }
        }
    }

    public void makeWater()
    {
        if (water < 90)
        {
            water = water + 10;
        }
        else if (water > 90 && water < 100)
        {
            water = maxWater;
        }
        oxygen = oxygen - 10;
        fuel = fuel - 20;
    }
}
