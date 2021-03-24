using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizOpener : MonoBehaviour
{
    public GameObject panel;
    public GameObject myself;
    // Start is called before the first frame update
    public void OpenPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
            myself.SetActive(false);
        }
    }

}
