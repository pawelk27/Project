using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public Light lt;

    public float duration = 1.0F;

    void Start()
    {
        
    }
    
    void Update()
    {
        float phi = Time.time / duration * 2 * Mathf.PI;
        float amplitude = Mathf.Cos(phi) * 0.5F + 0.25F;
        lt.intensity = amplitude;
    }
}
