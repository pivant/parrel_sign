using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold_tut_checker : MonoBehaviour
{
    public bool hold_tut_checker;

    void Start()
    {
        hold_tut_checker = false;
    }

    void OnTriggerEnter(Collider ohter)
    {
        hold_tut_checker = true;
    }

    void OnTriggerExit(Collider other)
    {
        hold_tut_checker = false;
    }

    
}
