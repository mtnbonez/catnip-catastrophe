using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundBehavior : MonoBehaviour
{
    public bool zoomEffect = true;
    public float zoomOutSpeed = 0.01f;

    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        t = GetComponent<Transform>();

        foreach (Transform child in t)
        {
            if (child.gameObject.tag != "trigger")
            {
                child.transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!zoomEffect)
        {
            foreach (Transform child in t)
            {
                if (child.gameObject.tag != "trigger" && child.transform.localScale.x >= 1.0f)
                {
                    child.transform.localScale = new Vector3(child.transform.localScale.x - zoomOutSpeed, child.transform.localScale.y - zoomOutSpeed, child.transform.localScale.z - zoomOutSpeed);
                }
            }
        }
    }

}
