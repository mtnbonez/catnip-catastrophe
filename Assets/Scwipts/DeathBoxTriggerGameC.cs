using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxTriggerGameC : MonoBehaviour
{
    DeathBoxBehaviorGameC dbbc;
    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        dbbc = GetComponentInParent<DeathBoxBehaviorGameC>();
        r2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dbbc.isDead = true;
        }
    }
}
