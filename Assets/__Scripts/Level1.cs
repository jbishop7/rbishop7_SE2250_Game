using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1 : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txt;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("main"))
        {
            Debug.Log("Prison Cell Room");
            txt.text = "Prison Cell";
        }
        if (other.gameObject.CompareTag("gym"))
        {
            Debug.Log("Gym Room");
            txt.text = "Gym";
        }
        if (other.gameObject.CompareTag("yard"))
        {
            Debug.Log("Yard Room");
            txt.text = "Yard";
        }
        if (other.gameObject.CompareTag("cafe"))
        {
            Debug.Log("Cafeteria Room");
            txt.text = "Cafeteria";
        }
        if (other.gameObject.CompareTag("main-gym"))
        {
            Debug.Log("Main-Gym Room");
            txt.text = "Main-Gym";
        }
        if (other.gameObject.CompareTag("cafeyard"))
        {
            Debug.Log("Yard-Cafe Room");
            txt.text = "Yard-Cafe";
        }
        if (other.gameObject.CompareTag("gymcafe"))
        {
            Debug.Log("Cafe-Gym Room");
            txt.text = "Cafe-Gym";
        }
        if (other.gameObject.CompareTag("hallway"))
        {
            Debug.Log("Hallway");
            txt.text = "Hallway";
        }
    }
}