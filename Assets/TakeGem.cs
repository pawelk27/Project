using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeGem : MonoBehaviour
{
    public GameObject Gem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            Destroy(Gem);
        }
    }
}
