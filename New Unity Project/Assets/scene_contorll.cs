using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scene_contorll : MonoBehaviour
{

    public void Change_to_level001()
    {
        SceneManager.LoadScene("level001");
    }

    public void Change_to_MainMenu()
    {
        SceneManager.LoadScene("main_menu_scene");
    }

    public void Change_to_Level002()
    {

    }

    public void Change_to_Intro()
    {
        SceneManager.LoadScene("introScene");
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
