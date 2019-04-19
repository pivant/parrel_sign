using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_tut : MonoBehaviour
{

    public GameObject wasd_moving; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Invoke("delay_Activate", 2);
    }

    void delay_Activate()
    {
        wasd_moving.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
