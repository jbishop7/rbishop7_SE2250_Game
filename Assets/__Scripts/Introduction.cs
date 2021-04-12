using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Introduction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DoSomething", 28); 
      
    }

    void DoSomething() { SceneManager.LoadScene("Customizer"); }
    // Update is called once per frame
    void Update()
    {
        
    }
}
