using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public bool inWindZone = false;
    public GameObject windZone;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (inWindZone)
        {
            rb.AddForce(windZone.GetComponent<WindArea>().direction * windZone.GetComponent<WindArea>().strength);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "windarea")
        {
            windZone = other.gameObject;
            inWindZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "windarea")
        {
            inWindZone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
