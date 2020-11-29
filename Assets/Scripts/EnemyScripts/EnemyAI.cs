using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    private Vector3 spawnPosition;
    private Vector3 roamingPosition;

    // Start is called before the first frame update
    private void Start()
    {
        spawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //random direction for enemies for testing purposes
    private Vector3 GetRoamingPosition()
    {
        return spawnPosition + GetRandomDirection() * Random.Range(10f, 70f);
    }

    //random direction for enemies for testing purposes
    public static Vector3 GetRandomDirection()
    {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, -1f)).normalized;
    }
}
