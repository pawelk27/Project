using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "teleport")
        {
            transform.position = new Vector3(0.131f, -0.316f, transform.position.z);
        }
    }
}
