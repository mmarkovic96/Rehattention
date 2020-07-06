using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level { level1, level2, level3, level4, level5, level6, level7, level8 };


public class LevelManager : MonoBehaviour
{

    static Level selectedLevel;

    static LevelManager instance;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }


    }


    public void setLevel(Level level)
    {
        selectedLevel = level;

        Debug.Log("Levet set -> " + selectedLevel);
    }

    public void setLevel(string level)
    {

       

        Level Level = (Level)System.Enum.Parse(typeof(Level), level);

        setLevel(Level);

        //Debug.Log("level set " + Level);

        if (Level.Equals(Level.level1) || Level.Equals(Level.level2) || Level.Equals(Level.level3) || Level.Equals(Level.level4))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScene");

        }

        else if(Level.Equals(Level.level5) || Level.Equals(Level.level6) || Level.Equals(Level.level7) || Level.Equals(Level.level8))
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene("VAAInstructionScene");

        }

        else
        {
            return;
        }


    }

    public Level getLevel()
    {
        Debug.Log("Returning " + selectedLevel);
        return selectedLevel;
    }
}
