using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    // Start is called before the first frame update
    private void Start()
    {
        StartBattle();
    }

    // Update is called once per frame
    private void StartBattle()
    {
        Debug.Log("Start Battle");

    }
}
