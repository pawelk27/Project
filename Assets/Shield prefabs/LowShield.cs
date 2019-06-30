using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowShield : MonoBehaviour
{
    public ParticleSystem shield;
    //public Light lighter;

    private void Start()
    {
        shield = GetComponent<ParticleSystem>();

        //lighter = GameObject.Find("ArcaneLight").GetComponent<Light>();
    }

    // Function responsible for switching on shield.
    public void Enable()
    {
        if (shield.isPlaying == false)
        {
            shield.Play();
            //lighter.enabled = true;
        }
    }

    // Function responsible for switching off shield.
    public void Disable()
    {
        if (shield.isPlaying == true)
        {
            shield.Stop();
            //lighter.enabled = false;
        }
    }
}
