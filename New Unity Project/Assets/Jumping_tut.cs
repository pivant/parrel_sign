using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_tut : MonoBehaviour
{
    public GameObject space_moving;

    void OnTriggerEnter(Collider other)
    {
        space_moving.SetActive(true);
    }

    void delay_Activate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
