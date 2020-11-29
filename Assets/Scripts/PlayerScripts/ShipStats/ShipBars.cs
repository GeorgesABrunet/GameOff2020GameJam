using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipBars : MonoBehaviour
{
    public Slider Engine; 
    public Slider Power; 
    public Slider Oxygen;    

    public void SetMaxHealth(int health)
    {
        Engine.maxValue = health;
        Engine.value = health;

        Power.maxValue = health;
        Power.value = health;

        Oxygen.maxValue = health;
        Oxygen.value = health;
    }
    public void SetEngineHealth(int health)
    {
        Engine.value = health;
    }

    public void SetPowerHealth(int health)
    {
        Power.value = health;
    }

    public void SetOxygenHealth(int health)
    {
        Oxygen.value = health;
    }
}
