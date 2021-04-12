using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float moveSpeed = 7f;
    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y - 3);
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            //Debug.Log("Hit!");
            Player.Instance.updateHealth(-15f);
            Destroy(gameObject);
            //col.GetComponent<Player>().updateHealth(-15f);
            
            Debug.Log(Player.Instance.getHealth());
        }
        if(col.gameObject.name.Equals("L3_walls"))
        {
            Destroy(gameObject);
        }
        
    }
}
