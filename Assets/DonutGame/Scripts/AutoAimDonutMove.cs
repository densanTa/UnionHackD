using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAimDonutMove : MonoBehaviour
{
    public float amplitude = 0.21f; // U•
    public float frequency = 1f; // ü”g”

 

    void Update()
    {
        // ŠÔ‚ğŒ³‚ÉZÀ•W‚ğŒvZ‚µA’PU“®‚ğs‚¢‚Ü‚·
        float z = -0.21f + amplitude * Mathf.Sin(Time.time * frequency);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,z );
    }
}

