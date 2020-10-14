using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxVelocity : MonoBehaviour
{
    float maxVelocity = 4;
    
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if(rb)
            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
    }
}
