using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_root : MonoBehaviour
{
    public GameObject moving_tut_01;
    public GameObject moving_tut_02;
    public GameObject jumping_tut_01;
    public GameObject holding_tut_02;
    public GameObject slow_tut;

    public GameObject canvas_text_01;
    public GameObject canvas_text_02;
    public GameObject hold_canvas_text;
    public GameObject open_door_text;
    public GameObject e_moving;
 

    Tut001_checker root_checker_01;
    Tut002_checker root_checker_02;
    collider_destroy root_checker_03;

    Hold_tut_checker hold_Tut_Checker;

    PlayerMove playermove;

    slow_tut_out Slow_Tut_Out;


    bool tutorial_count_01;
    bool tutorial_count_02;

    // Start is called before the first frame update
    void Start()
    {
        tutorial_count_01 = false;
        tutorial_count_02 = false;
        root_checker_01 = GameObject.Find("moving_tut_01").GetComponent<Tut001_checker>();
        root_checker_02 = GameObject.Find("moving_tut_02").GetComponent<Tut002_checker>();
        root_checker_03 = GameObject.Find("jumping_tut_01").GetComponent<collider_destroy>();

        Slow_Tut_Out = GameObject.Find("slow_tut_effect").GetComponent<slow_tut_out>();

        hold_Tut_Checker = GameObject.Find("Cube").GetComponent<Hold_tut_checker>();
        playermove = GameObject.Find("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if(root_checker_01.moving_tut_checker == true)
        {
            tutorial_count_01 = true;
            moving_tut_01.SetActive(false);
        }

        if(root_checker_02.moving_tut_checker == true)
        {
            tutorial_count_02 = true;
            moving_tut_02.SetActive(false);
        }

        if(tutorial_count_01 == true && tutorial_count_02 == true)
        {
            canvas_text_01.SetActive(false);
        }

        if(root_checker_03.checker == true)
        {
            canvas_text_02.SetActive(false);
            jumping_tut_01.SetActive(false);
        }

        if(hold_Tut_Checker.hold_tut_checker == true)
        {
            hold_canvas_text.SetActive(true);
        }

        if(playermove.is_holding_item == true)
        {
            hold_canvas_text.SetActive(false);
            open_door_text.SetActive(true);
        }

        //if(playermove.ret_ret == true)
        //{
        //    open_door_text.SetActive(true);
        //}

        if(playermove.solve == true)
        {
            open_door_text.SetActive(false);
        }

        if(Slow_Tut_Out.pannel_through_checker == true)
        {
            e_moving.SetActive(false);
            slow_tut.SetActive(false);
        }

    }
}
