﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_open : MonoBehaviour
{
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
      if(GameObject.Find("Player").GetComponent<PlayerMove>().solve == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x < -10)
                transform.position = new Vector3(-10, -6.4f, 8);
        }
    }
}
