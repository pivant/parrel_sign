using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pannel_drag : MonoBehaviour
{

    public Rigidbody rigidbody;
    //public bool slowChecker;

    public PlayerMove playermove = null;

    // Start is called before the first frame update
    void Start()
    {
        //slowChecker = false;
       rigidbody = GetComponent<Rigidbody>();
        this.playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playermove.slowChecker == true)
        {
            rigidbody.drag = 3f;
        }
    }
}
