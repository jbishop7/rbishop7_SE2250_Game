using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;

    private void Start()
    {
    }
    private void Update()
    {
    }
    public virtual void VentClicked()
    {
            player.transform.position = new Vector3(10, -20);
    }
}
