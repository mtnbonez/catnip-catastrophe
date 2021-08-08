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
    // 4 = TheGame
    [SerializeField]
    GameObject pauseMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(4);
    }
    public void Credits()
    {
        SceneManager.LoadScene(2);
    }
    public void MainMenuReturn()
    {
        SceneManager.LoadScene(0);
        AudioListener.pause = false;
    }
    public void ClosePause()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
    }
}
