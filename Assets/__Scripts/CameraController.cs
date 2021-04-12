using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI invText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI levelText;
    

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        if (Player.Instance != null)
        {
            playerHealthText.text = "HP: " + Player.Instance.getHealth() + "/" + Player.Instance.getMaxHealth();
            scoreText.text = "Score: " + Player.Instance.getScore();

            if (!Player.Instance.getLevel1())
            {
                levelText.text = "Level: 1/3";
            }
            if (Player.Instance.getLevel1())
            {
                levelText.text = "Level: 2/3";
            }
            if (Player.Instance.getLevel1() && Player.Instance.getLevel2())
            {
                levelText.text = "Level: 3/3";
            }


            if (Player.Instance.isBulletProof())
            {
                invText.text = "Invincible";
            }
            else if (!Player.Instance.isBulletProof())
            {
                invText.text = " ";
            }

        }
    }
}

