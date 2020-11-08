using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationDoor : MonoBehaviour
{
    private Animator anim;
    public static bool ShipStart = false;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenuScript.GoTime == true)
        {
            ShipStart = true;
            anim.SetBool("DoorOpen", true);
        }
        else
        {
            ShipStart = false;
            anim.SetBool("DoorOpen", false);
        }
    }
}
