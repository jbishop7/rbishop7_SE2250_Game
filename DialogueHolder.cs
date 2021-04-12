using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    //public string dialogue;
    private DialogueManager dMan;
    public bool questNpc = false;
    public bool level2 = false;
    public bool guard = false;
    public bool gun = false;
    public bool level3 = false;
    public GameObject trigger;
    private int counter = 0; //might remove this later. but for now, this is here to ensure that the message only gets displayed once. 
    private int counter1 = 0;
    private int counterGuard = 0; //to know that this is the first time he is meeting the guard. 
    private int counterGun = 0;
    private int counter3 = 0;
    private Player player;

    public string[] dialogueLines;
    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        player = FindObjectOfType<Player>();     
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(Input.GetMouseButtonUp(1))
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                //dMan.ShowBox(dialogue);
                if (questNpc)
                {
                    dMan.showButton();
                }
                trigger.SetActive(false);
            }
            if (level2 && counter == 0)
            {
                dMan.NextLevel();
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                counter++;
                trigger.SetActive(false);
            }
            if(player.GetLevel2Complete() && counter1 == 0)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                counter1++;
                trigger.SetActive(false);
            }
            if(guard && counterGuard == 0)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                counterGuard++;
                trigger.SetActive(false);
            }
            if (gun && counterGun == 0)
            {
                counterGun = 2;
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                trigger.SetActive(false);

            }
            if(level3 && counter3 == 0)
            {
                dMan.dialogueLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                counter3++;
                trigger.SetActive(false);
            }
        }
    }

    public int getGunCounter()
    {
        return counterGun;
    }

    
}
