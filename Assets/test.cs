using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject shield, player;

    void ChangeParent()
    {
        shield.transform.SetParent(player.transform);
    }
}
