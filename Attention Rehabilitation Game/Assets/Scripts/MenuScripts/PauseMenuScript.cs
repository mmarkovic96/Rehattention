using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;

    public void LoadScene(string Scene)
    {


        UnityEngine.SceneManagement.SceneManager.LoadScene(Scene);
        Time.timeScale = 1f;

    }

    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

    }

    public void Pause()
    {

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void Menu()
    {

        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");

    }

    public void Quit()
    {

        Application.Quit();


    }

    public void Restart()
    {
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        GameIsPaused = false;
        string scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);


    }

    public void Instructions()
    {

        Level Level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

        if (Level.Equals(Level.level1) || Level.Equals(Level.level2) || Level.Equals(Level.level3) || Level.Equals(Level.level4))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScene");

        }

        else
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("VAAInstructionScene");

        }

    }
}
