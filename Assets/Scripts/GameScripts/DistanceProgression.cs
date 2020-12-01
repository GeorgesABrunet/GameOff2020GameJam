using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceProgression : MonoBehaviour
{
   public Slider ProgressSlider;    

    public void SetMaxDistance(int waves)
    {
        ProgressSlider.maxValue = waves;
        ProgressSlider.value = waves;
    }
    public void SetDistance(int waves)
    {
        ProgressSlider.value = waves;
    }
}
