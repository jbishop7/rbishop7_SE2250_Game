using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float speed = 2;

    private Animator anim;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D rb;

    public bool isWalking;

    //time that the NPCs should keep walking
    public float walk = 5;
    private float wCount; //walk count
    //time that the NPC should stand
    public float stand=1;
    private float sCount; //stand count

    private int direction;

    public Collider2D walkingArea;
    private bool hasWalkArea;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sCount = stand;
        wCount = walk;

        chooseDirection();

        if(walkingArea != null) //so that some villagers may have the ability to walk anywhere
        {
            minWalkPoint = walkingArea.bounds.min; //bottom left
            maxWalkPoint = walkingArea.bounds.max; //top right
            hasWalkArea = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isWalking)
        {
            wCount -= Time.deltaTime;
            
            
            switch(direction)
            {
                case 0:
                    rb.velocity = new Vector2(0, speed); //moving up
                    anim.SetFloat("MoveY", speed);
                    anim.SetFloat("MoveX", 0);
                    if (hasWalkArea && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        sCount = stand;
                        
                    }
                    break;
                case 1:
                    rb.velocity = new Vector2(speed, 0); //moving right
                    anim.SetFloat("MoveX", speed);
                    anim.SetFloat("MoveY", 0);
                    if (hasWalkArea && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        sCount = stand;
                        
                    }
                    break;
                case 2:
                    rb.velocity = new Vector2(0, -speed); //moving down
                    anim.SetFloat("MoveY", -speed);
                    anim.SetFloat("MoveX", 0);
                    if (hasWalkArea && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        sCount = stand;
                     
                    }
                    break;
                case 3:
                    rb.velocity = new Vector2(-speed,0); //moving left
                    anim.SetFloat("MoveX", -speed);
                    anim.SetFloat("MoveY", 0);
                    if (hasWalkArea && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        sCount = stand;
                    }
                    break;
            }

            if (wCount < 0)
            {
                isWalking = false;
                sCount = stand;
                //anim.SetFloat("MoveX", 0);
            }
        }
        else
        {
            sCount -= Time.deltaTime;

            rb.velocity = Vector2.zero;

            if(sCount < 0)
            {
                chooseDirection();
            }
        }

        //anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        //anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
    }

    public void chooseDirection()
    {
        direction = Random.Range(0, 4);
        isWalking = true;
        wCount = walk;
    }
}
