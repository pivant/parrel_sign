using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_tut : MonoBehaviour
{
    public GameObject e_moving;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        e_moving.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
