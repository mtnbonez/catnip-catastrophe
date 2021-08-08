using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBoxTrigger : MonoBehaviour
{
    DeathBoxBehavior dbb;
    Rigidbody2D r2d;

    // Start is called before the first frame update
    void Start()
    {
        dbb = GetComponentInParent<DeathBoxBehavior>();
        r2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            dbb.isDead = true;
        }
    }
}
