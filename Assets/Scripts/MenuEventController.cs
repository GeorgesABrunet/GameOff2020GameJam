using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEventController : MonoBehaviour
{
    public static int SpaceCowAppear;

    void Start()
    {
        SpaceCowAppear = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpaceCowAppear = SpaceCowAppear + 1;
        }
    }
}
