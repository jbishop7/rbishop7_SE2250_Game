using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathControl : MonoBehaviour   //OK SO THIS SCRIPT IS NOW A CONTROLLER FOR ALL POPUPS MADE BY ROBERT!!!!
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
