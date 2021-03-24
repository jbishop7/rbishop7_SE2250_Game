using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMan;
    public bool questNpc = false;

    // Start is called before the first frame update
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            if(Input.GetMouseButtonUp(0))
            {
                dMan.ShowBox(dialogue);
                if (questNpc)
                {
                    dMan.showButton();
                }
            }
        }
    }
}
