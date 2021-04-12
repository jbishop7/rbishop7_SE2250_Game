using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCEnemy : NPCMovement
{
    public TMP_Text mainScore;
    private float health = 100f;
    

    public GameObject dmgIndicator;
    public GameObject dmgPlayerIndicator;

    
    //public bool agro = true;       //set this to true when we start the fight, so when we talk to the NPC we are going to fight. 
    public Transform attackPoint;       //the middle where the attack pioint starts
    public float attackRange = 0.3f;   //the radius of area where the enemy can hit the player. 
    public LayerMask playerLayers;      //set this to the player layer!!!!!

    public float attackCoolDown = 1.5f;       //1.5f is best !!
    public float coolDown;
    public bool agro = false;

   

    // Start is called before the first frame update
    void Start()
    {
        
        coolDown = attackCoolDown;
       
    }

    // Update is called once per frame
    public override void Update()
    {
        coolDown -= Time.deltaTime;
        if (coolDown < 0 && agro)       //THIS IS WHERE I WANT TO USE AGRO!!!
        {
            Attack();
            coolDown = attackCoolDown;
        }
        targetPlayer();
       


    }
    

    public virtual void takeDamage(float dmg)
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        Instantiate(dmgIndicator, pos, Quaternion.identity);
        health -= dmg;
        Debug.Log("Enemy HP: " + health);


        
        //play a animation? Probably just update the health? Or have no health bar?

        if (health <= 0)
        {
            Die();
            

        }
    }
    public virtual void Die()
    {
        Player.Instance.increaseKills();
        Player.Instance.increaseScore(5);

        transform.rotation = Quaternion.Euler(Vector3.forward * 90);
        this.enabled = false;
        
        
       // Debug.Log("Enemy is dead");
        //do something for when they die? Maybe they just die? Or do they go to the ER? I don't know. 
        //Make him just rotate and fall on the ground and not move now??!?!?!? SEE BRACKEYS VID FOR LAST BIT
    }

    public virtual void Attack()
    {
        float choice = Random.Range(0, 100);
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        //damage the enemy. 
        if (choice > 30f && hitEnemies.Length > 0)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                Vector3 pos = new Vector3(Player.Instance.transform.position.x, Player.Instance.transform.position.y - 0.5f, 0f);
                enemy.GetComponent<Player>().updateHealth(-1f*Random.Range(4, 10));  //make this random ish?
                Instantiate(dmgPlayerIndicator, pos, Quaternion.identity);
                
                
            }
        }
    }

    public virtual void targetPlayer()
    {
        Vector2 playerPos = Player.Instance.playerRB.position;
        Vector3 targetVector = new Vector3(playerPos.x - transform.position.x, playerPos.y - transform.position.y, 0f);  //these get a vector that points to the player
        //Debug.Log("Length: " + targetVector.sqrMagnitude);
        if (targetVector.sqrMagnitude <= 40 || agro)    //make sure he isn't always running to the player. 
        {
            agro = true;
            transform.position += targetVector.normalized * speed * Time.deltaTime;
        }
        

    }

   

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}

