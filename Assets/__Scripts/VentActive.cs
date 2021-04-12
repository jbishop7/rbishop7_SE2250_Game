using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentActive : MonoBehaviour
{
    public GameObject ventButton;
    public GameObject ventButton2;
    public int ventNumber = 0;
    // Start is called before the first frame update
    private Player player;
    public GameObject ventInfo;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(player.isGunFound() )
        {
            ventInfo.SetActive(true);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && player.isGunFound())
        {
            ventButton.SetActive(true);
            if(ventNumber ==3)
            {
                ventButton.SetActive(false);
                ventButton2.SetActive(true);
            }

       }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            ventButton.SetActive(false);
            ventButton2.SetActive(false);
        }
    }
     public int getVentNumber()
    {
        return ventNumber;
    }
}
