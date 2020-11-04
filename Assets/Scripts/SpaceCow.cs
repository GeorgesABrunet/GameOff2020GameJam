using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCow : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool spinning;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spinning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (MenuEventController.SpaceCowAppear >= 5)
        {
            spinning = true;
        }

        if (spinning == true)
        {
            rb.velocity = new Vector2(-0.2f,-0.2f);
            transform.Rotate(0, 0, 2, Space.World);
        }
        
    }
}
