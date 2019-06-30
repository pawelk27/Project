using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeStar : MonoBehaviour
{
    public float starSum;
    public GameObject star;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            starSum++;
            Destroy(star);
        }
    }
}
