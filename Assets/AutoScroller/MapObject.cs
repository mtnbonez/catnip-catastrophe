using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    Transform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        // Update all objects to move right-to-left
        tr.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}
