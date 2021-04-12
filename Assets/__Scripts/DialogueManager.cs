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

    public string[] dialogueLines;
    public int currentLine;


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
            //dBox.SetActive(false);
            //dialogueActive = false;

            currentLine++;
        }
        if(currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
        }

        dText.text = dialogueLines[currentLine]; 
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

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
    }
    public void NextLevel()
    {
        startQuiz.SetActive(false);
        dBox.SetActive(false);
    }
}
