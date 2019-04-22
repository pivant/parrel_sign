using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_destroy : MonoBehaviour
{
    public bool checker;

    void Start()
    {
        checker = false;
    }

    void OnTriggerEnter(Collider other)
    {
        checker = true;
    }
}
