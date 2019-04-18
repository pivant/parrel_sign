using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_disable : MonoBehaviour
{
    bool checker;

    // Start is called before the first frame update
    void Start()
    {
        checker = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && checker == false )
        {
            checker = true;
            this.enabled = false;
        }

        if(GameObject.Find("Dialogue_sc").GetComponent<Dialogue_root>().dialogue_end == true)
        {
            this.enabled = true;
        }

        if(Input.anyKeyDown && checker == true)
        {
            //SceneManager.LoadScene("level001");
        }

    }
}
