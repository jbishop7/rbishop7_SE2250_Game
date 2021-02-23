using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");

        Vector3 pos = transform.position;
        pos.x += xPos * speed * Time.deltaTime;
        pos.y += yPos * speed * Time.deltaTime;
        transform.position = pos;

    }
}
