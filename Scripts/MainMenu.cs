using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject PausePanel;
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        print("QUIT");
        Application.Quit();
    }

    public void ResumeGame()
    {
        print("resume");
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
