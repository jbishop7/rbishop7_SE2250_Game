using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuardEnemy : NPCEnemy
{
    [SerializeField]
    GameObject bullet;

    float fireRate;
    float nextFire;

    private void Start()
    {
        fireRate = 3f;
        nextFire = Time.time;
    }
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

    public override void takeDamage(float dmg)
    {
        base.takeDamage(dmg);
    }

    public override void Die()
    {
        Player.Instance.increaseKills();
        Player.Instance.increaseScore(10f);
        transform.rotation = Quaternion.Euler(Vector3.forward * 90);

        //put your code before this line. 
        this.enabled = false;
    }

    public override void Attack()
    {
        if(Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

    }

    public override void targetPlayer()
    {
        Vector2 playerPos = Player.Instance.playerRB.position;
        Vector3 targetVector = new Vector3(playerPos.x - transform.position.x, playerPos.y - transform.position.y, 0f);  //these get a vector that points to the player
        //Debug.Log("Length: " + targetVector.sqrMagnitude);
        if (targetVector.sqrMagnitude <= 40 && targetVector.sqrMagnitude >= 5)    //make sure he isn't always running to the player. 
        {
            agro = true; 
            transform.position += targetVector.normalized * speed * Time.deltaTime;
        }
    }


}
