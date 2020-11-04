using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLaunch : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Ship;
    public GameObject Blast;
    public Animator anim2;
    void Start()
    {
        Blast = Ship.transform.Find("ShipBlast").gameObject;
        rb = GetComponent<Rigidbody2D>();
        anim2 = Blast.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StationDoor.ShipStart == true)
        {
            anim2.SetBool("Blasting", true);
            rb.velocity = new Vector2(1.2f,-0.1f);
        }
    }
}
