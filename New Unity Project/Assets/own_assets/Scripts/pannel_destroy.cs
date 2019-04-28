using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pannel_destroy : MonoBehaviour
{
    

    void OnTriggerEnter(Collider otherObj)
    {
        //Debug.Log("폴링패드 충돌");
        if (otherObj.gameObject.tag == "falling_pad")
        {
            //Debug.Log("폴링패드 제거");
            Destroy(otherObj.gameObject, 0.5f);
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
