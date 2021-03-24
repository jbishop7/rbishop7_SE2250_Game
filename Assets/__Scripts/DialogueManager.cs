using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dBox;
    public Text dText;
    public GameObject startQuiz;

    public bool dialogueActive;


    // Start is called before the first frame update
    void Start()
    {
        startQuiz.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            dBox.SetActive(false);
            dialogueActive = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void showButton()
    {
        //buttonActive = true;
        startQuiz.SetActive(true);
    }
}
