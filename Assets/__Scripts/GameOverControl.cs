using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    public GameObject endMsg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(endMsg, Player.Instance.playerRB.transform);
            Time.timeScale = 0;
        }
    }
}
