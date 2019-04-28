using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tut_end : MonoBehaviour
{
   void OnTriggerEnter(Collider collider)
    {
        SceneManager.LoadScene("level002");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
