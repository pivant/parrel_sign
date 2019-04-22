using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut001_checker : MonoBehaviour
{
    public bool moving_tut_checker;

    // Start is called before the first frame update
    void Start()
    {
        moving_tut_checker = false;
    }

    void OnTriggerEnter(Collider other)
    {
        moving_tut_checker = true;
    }

}
