using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_root : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    float timer;
    float waiting_time;
    bool time_checker;

    public bool dialogue_end;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        timer = 0.0f;
        waiting_time = 2.5f;
        time_checker = false;
        dialogue_end = false;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("대화시작 with");

        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    void Dealy()
    {
        time_checker = false;
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EnDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log("대화중");

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    void EnDialogue()
    {
        Debug.Log("대화끝");
        dialogue_end = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>waiting_time )
        {
            timer = 0;
            DisplayNextSentence();

        }
    }
}
