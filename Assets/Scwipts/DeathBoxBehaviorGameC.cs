using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathBoxBehaviorGameC : MonoBehaviour
{
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            SceneManager.LoadScene("TheGameC");
        }
    }
}
