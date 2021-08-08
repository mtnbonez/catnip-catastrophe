using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainTriggerScript : MonoBehaviour
{
    RainBehavior rb;
    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<RainBehavior>();
        r2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            rb.startRain = true;
        }
    }
}
