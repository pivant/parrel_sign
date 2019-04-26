using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slow_tut_out : MonoBehaviour
{
    public bool pannel_through_checker;

    // Start is called before the first frame update
    void Start()
    {
        pannel_through_checker = false;
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject other_go = other.gameObject;

        if(other_go.layer == LayerMask.NameToLayer("Player"))
        {
            pannel_through_checker = true;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
