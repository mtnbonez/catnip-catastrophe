using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoomTriggerScript : MonoBehaviour
{
    backgroundBehavior bgb;
    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        bgb = GetComponentInParent<backgroundBehavior>();
        r2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            bgb.zoomEffect = false;
        }
    }
}
