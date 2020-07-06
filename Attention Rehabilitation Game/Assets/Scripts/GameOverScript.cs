using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{

    Level Level;
    // Start is called before the first frame update
    void Start()
    {

        Level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

    }


    public void Play()
    {

        if (Level.Equals(Level.level1) || Level.Equals(Level.level2) || Level.Equals(Level.level3) || Level.Equals(Level.level4))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("VisualAttGame");

        }

        else
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("VisAuAttGame");

        }

    }

    public void Menu()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");

    }
}
