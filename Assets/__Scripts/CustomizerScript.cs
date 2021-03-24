using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomizerScript : MonoBehaviour
{
    public SpriteRenderer bodypart;
    public List<Sprite> options = new List<Sprite>();
    
    
    private int currentOption = 0;
    public void BrainOrBrawn(bool b)
    {
        if (b == true) {//brawn
            Player.brains = false;
        }
        else {//brain
            Player.brains = true;
        }
        SceneManager.LoadScene("Scene1");
        
    }
    public void BlackOrBald(bool b)
    {
        if (b == true) {//black
            Player.hair = true;  
        
        }
        else { //bald
            Player.hair = false;
        }
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
