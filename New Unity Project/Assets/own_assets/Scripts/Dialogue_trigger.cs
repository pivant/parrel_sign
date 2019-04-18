using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue_trigger : MonoBehaviour
{
    public GameObject press_any_key;
    public Dialogue dialogue;
    
    bool checker;
    bool checker_2;

    public void TriggerDialogue()
    {
        checker = false;
        FindObjectOfType<Dialogue_root>().StartDialogue(dialogue);
    }

    void Update()
    {
        if (Input.anyKeyDown && checker == false)
        {
            TriggerDialogue();
            checker = true;
            press_any_key.SetActive(false);
        }

        if (GameObject.Find("Dialogue_sc").GetComponent<Dialogue_root>().dialogue_end == true)
        {
            press_any_key.SetActive(true);
        }

        if (Input.anyKeyDown && GameObject.Find("Dialogue_sc").GetComponent<Dialogue_root>().dialogue_end == true)
        {
            SceneManager.LoadScene("level001");
        }
    }
}
