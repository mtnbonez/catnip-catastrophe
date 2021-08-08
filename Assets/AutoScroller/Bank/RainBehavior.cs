using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainBehavior : MonoBehaviour
{
    public bool startRain = false;
    GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in GetComponent<Transform>())
        {
            if (child.gameObject.tag == "rain")
            {
                prefab = child.gameObject;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (startRain && !prefab.activeSelf)
        {
            prefab.SetActive(true);
        }
    }
}
