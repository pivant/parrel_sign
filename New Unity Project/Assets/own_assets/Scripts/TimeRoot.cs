using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRoot : MonoBehaviour
{
    public float slowdownFactor = 0.1f;
    public float slowdownLength = 8f;
    public PlayerMove playermove;
    public GUIStyle guistyle;
    public float plusMove = 20;
    float x = Screen.width / 2;
    float y = Screen.height / 2;
    bool slowChecker = false;

    void Update()
    {
        timeChecker();
    }

    public void ClockUP()
    {
        slowChecker = !slowChecker;
        Time.timeScale = slowChecker ? slowdownFactor : 1f;

        playermove.movementSpeed = slowChecker ? playermove.movementSpeed * 1 / Time.timeScale : 6f;
        //playermove.jumpPower = slowChecker ? playermove.jumpPower * 1/Time.timeScale : 1f;

        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void timeChecker()
    {
        
    }

}
