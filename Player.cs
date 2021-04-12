using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public float speed = 5f;
    public Rigidbody2D playerRB;    //we move with this!!!!!! DONT DELETE
    public Camera cam; //this is used in the mouse aiming for shooting
    
    private float maxHealth = 100f;
    Vector2 movement;   //store x and y 
    Vector2 mousePos;
    

    private static float maxDmg = 10;

    
    

    public Tilemap level1Walls; //used to take down the walls after level 1
    public Tilemap level2Walls; //same as above but for level 2
    public GameObject deathMsg;

    public Animator animator;   //our animator ot make the character move and stuff
    //ATTRIBUTES OF PLAYER THAT WE WANT TO INITIALZIE AND STUFF
    
    private bool level1Complete = false; //set to false when done testing
    private bool level2Complete = false;

    private float health;

    public Transform attackPoint;
    public GameObject bulletPrefab;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public GameObject onHead;

    public static bool hair;
    public static bool brains;

    private bool gun = false;
    private bool vent3 = false;      //this has to be false when the game actually starts
    private bool l3start = true;    //this can be true, MAYBE when its false we can start the shooting?

    private int kills = 0;
    private float atkSpeed = 1;
    private float atkCoolDown = 1;
    private bool bulletproof = false;
    private float bpCoolDown = 30f;
    private float bpTimer = 10f;
    private float bpUseTimer = 30f;
    private float score = 0;

    Vector2 shootDir;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        if (Instance != null)
        {
            init();

        }
        
        this.health = maxHealth;
        //DontDestroyOnLoad(gameObject);
      
    }

    public virtual void init()
    {
        this.health = Instance.getHealth();
        this.maxHealth = Instance.getMaxHealth();
        
    }


    private void Start()
    {
        
        if (hair == false)
        {
            Destroy(onHead);    //if they dont want black on top then destroy the afro


        }

        if (brains == false)
        {
            maxDmg += 5;    //if they choose to not be smart then they get a buff to damage
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //get inputs
        speed = 5f;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //not gonna rotate the player

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("run", false);

        if (Input.GetKey(KeyCode.LeftShift) && level1Complete)
        {
            animator.SetBool("run", true);
            speed = 10f;
        }

        atkCoolDown -= Time.deltaTime;
        

        if (Input.GetKeyDown(KeyCode.Mouse0) && level1Complete && atkCoolDown < 0)
        {
            atkCoolDown = atkSpeed;     //IF SOMETHING BREAKS IT IS LIKELY THIS!!!!!
            Attack();
        }

        bpUseTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F) && level2Complete && bpUseTimer <= 0)
        {
            if (!bulletproof)
            {
                bulletproof = true;
                bpUseTimer = bpCoolDown;
                bpTimer = 10f;
            }
            else
            {
                Debug.Log("Can't do that yet!");
            }
        }

        if (bulletproof)
        {
            bpTimer -= Time.deltaTime;
            if (bpTimer < 0)
            {
                bulletproof = false;
            }
        }



        checkLevelOneCompletion();
        checkLevelTwoCompletion();

        if (l3start && gun && vent3)
        {
            startLevel3();
        }


        if (health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + movement*speed*Time.fixedDeltaTime);  //moves the player

        shootDir = mousePos - playerRB.position;

    }

    public bool isBulletProof()
    {
        return bulletproof;
    }

    public void increaseScore(float s)
    {
        score += s;
        Debug.Log("Score: " + score);
    }

    public float getScore()
    {
        return score;
    }

    public Vector3 getShootDir()
    {
        Vector3 dir = new Vector3(shootDir.x, shootDir.y, 0f);
        return dir;
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

    public void checkLevelTwoCompletion()
    {
        if (level2Complete)
        {
            level2Walls.ClearAllTiles();
        }
    }

    public void level2Completed()
    {
        level2Complete = true;
        //maybe buff the players stats here?
        setHealth(maxHealth);
        
    }

    public bool GetLevel2Complete()
    {
        return level2Complete;
    }
    public void startLevel3()
    {
        transform.position = new Vector3(58f, -24f, 0f);
        l3start = false;            //maybe use this to allow him to fire?
    }

    public bool Brain()
    {
        return brains;
    }

    public void Level3Vent()
    {
        l3start = true;
        gun = true;
        vent3 = true;
    }
    

    public void setHealth(float h)  //use to set the health to a value. 
    {
        health = h;
    }
    public void updateHealth(float h)   //use to decrease health when fighting, or increase if regeneration is possible. 
    {
        //if h is positive check that health cant go over max health
        if (bulletproof && h <= 0)
        {
            Debug.Log("No damage take due to bulletproof");
        }
        if (!bulletproof)
        {
            health += h;
        }
    }
    public float getHealth()
    {
        return health;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }

    void Attack()
    {
        if (gun && transform.position.x > 25)   //if he has the gun and is not on the main map (so he has to be on level 3)
        {
            projectileAttack();     //attack with the gun. shoot projectiles. 
        }
        else
        {
            meleeAttack();
        }
        
    }
    
    void projectileAttack()
    {
       
        Instantiate(bulletPrefab);

        //Debug.Log("Hello from projectile attack");
    }

    void meleeAttack()
    {
        //not gonna do animation but instead a punch effect on the enemy, or show how much hp they lost
        //detect enemies in range of the attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        //damage the enemy. 
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<NPCEnemy>().takeDamage(Random.Range(maxDmg - 5, maxDmg));  //make this random ish?
            //Debug.Log("Kills: " + kills);
        }
    }
    public Vector2 getPosition()
    {
        return movement;
    }

    public void increaseKills()
    {
        kills++;
        if (kills >= 1 && level2Complete == false)
        {
            level2Completed();  //call method to do some things for us. 
        }
    }


    public void Die()
    {
        if (level1Complete && !level2Complete)
        {
            transform.position = new Vector2(-4.8f, 4.3f);   //put him into a bed 
            health = maxHealth;

            Instantiate(deathMsg, playerRB.transform);
            
        }
    }

    public void gotGun()
    {
        gun = true;
    }

    public bool isGunFound()
    {
        return gun;
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
