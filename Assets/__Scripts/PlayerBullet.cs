using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    Vector2 dir;
    float moveSpeed = 7;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.position = Player.Instance.attackPoint.position;
        dir = Player.Instance.getShootDir();       //remember to normalzie after!

        dir = dir.normalized * moveSpeed;
        rb.velocity = new Vector2(dir.x, dir.y);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "walls")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hello we hit an enemy");
            
            Destroy(gameObject);
            collision.GetComponent<GuardEnemy>().takeDamage(50f);
        }
        

    }


}
