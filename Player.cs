using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{

    static public Player player;

    public float speed = 5f;
    public Rigidbody2D playerRB;
    public KeyCode run;
    public float maxHealth = 100;
    Vector2 movement;   //store x and y 

    public Tilemap level1Walls;
    public Tilemap level2Walls;

    public Animator animator;
    //ATTRIBUTES OF PLAYER THAT WE WANT TO INITIALZIE AND STUFF
    private float health;

    private bool level1Complete = false;

    

    private void Awake()
    {
        if (player == null)
        {
           player = this;
           this.health = maxHealth;
        }
    }

   // Update is called once per frame
    void Update()
    {
        //get inputs
        speed = 5f;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("run", false);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("run", true);
            speed = 10f;
        }

        if (level1Complete == false)
        {
            checkLevelOneCompletion();
        }


    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement*speed*Time.fixedDeltaTime);
    }

   void checkLevelOneCompletion()
    {
       if (level1Complete == true)
       {
        level1Walls.ClearAllTiles();    //should clear all tiles in that tilemap, opening the world up a bit more. 
       }
    }
    public void LevelComplete()
    {
        level1Complete = true;
    }
}
