using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_telle : MonoBehaviour
{
    public Transform reposition;
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("충돌이벤트 발생");
            other.transform.position = reposition.position;
            Debug.Log("플레이어 이동됨");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
