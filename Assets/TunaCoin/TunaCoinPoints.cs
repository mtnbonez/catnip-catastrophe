using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TunaCoinPoints : MonoBehaviour
{
    // Start is called before the first frame update

    // right now, button press to add points, make points change the score (D-S) 
    // screen to tally points and give score, option to restart, or back to main menu
    // also think about option for the escape menu to restart level or go back to main menu.

    // close the game loop so we can go from main menu to play, back to main menu.

    [SerializeField]
    GameObject pauseMenu;

    public int score = 0;

    [SerializeField]
    Text scoreT;

    [SerializeField]
    Text rankT;
    void Start()
    {
        if (pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
        }
        Time.timeScale = 1;
        AudioListener.pause = false;

    }

    // Update is called once per frame
    void Update()
    {
        scoreT.GetComponent<UnityEngine.UI.Text>().text = score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                AudioListener.pause = true;
            }
            else if (pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                AudioListener.pause = false;
            }
        }






        if (score == 10)
            rankT.GetComponent<UnityEngine.UI.Text>().text = "E";

        if (score == 20)
            rankT.GetComponent<UnityEngine.UI.Text>().text = "D";

        if (score == 30)
            rankT.GetComponent<UnityEngine.UI.Text>().text = "C";

        if (score == 17)
            rankT.GetComponent<UnityEngine.UI.Text>().text = "B";

        if (score == 18)
            rankT.GetComponent<UnityEngine.UI.Text>().text = "A";
    }


}
