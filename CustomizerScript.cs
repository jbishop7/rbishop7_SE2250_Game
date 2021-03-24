using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerScript : MonoBehaviour
{ public GameObject gameObject;
    public SpriteRenderer bodypart;
    public List<Sprite> options = new List<Sprite>();
    
    private int currentOption = 0;
    public void BrainOrBrawn(bool b)
    {
        if (b == true) {//brawn q
            QuizManager a = new QuizManager();
            a.setThisBrain(false);
        }
        else {//brain
            QuizManager c = new QuizManager();
            c.setThisBrain(true);

        };
        SceneManager.LoadScene("Scene1");
        
    }
    public void BlackOrBald(bool b)
    {
        if (b == true) {//black
           
        
        }
        else {
        };
    }
    public void setBrawn() {
        BrainOrBrawn(true);
    }
    public void setBrain()
    {
        BrainOrBrawn(false);
       
    }
    public void setBlack()
    {
        BlackOrBald(true);
    }
    public void setBald()
    {
        BlackOrBald(false);
        
    }
    public static CustomizerScript customizer { get; private set; }
    public int spriteChoice;


    


    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;        
        }
        bodypart.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1; 
        }
        bodypart.sprite = options[currentOption];
    }

    

}
