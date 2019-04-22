using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping_tut : MonoBehaviour
{
    public GameObject space_moving;

    void OnTriggerEnter(Collider other)
    {
        Invoke("delay_Activate", 0.5f);
    }

    void delay_Activate()
    {
        space_moving.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
