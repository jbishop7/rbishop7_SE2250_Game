using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour
{
    public float effectTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        if (Player.Instance.getHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        effectTime -= Time.deltaTime;
        transform.localScale += new Vector3(-0.01f, -0.01f, 0f);

        if (effectTime < 0)
        {
            Destroy(gameObject);
        }

    }
}
