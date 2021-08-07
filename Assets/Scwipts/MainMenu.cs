using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // 0 = MainMenu
    // 1 = SampleScene
    // 2 = Credits
    // 3 = AutoScroll

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenuReturn()
    {
        SceneManager.LoadScene(0);
    }
}
