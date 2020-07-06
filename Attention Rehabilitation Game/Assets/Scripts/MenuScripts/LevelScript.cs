using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    //string level;

    Level Level;


    private void OnMouseDown()
    {
        string level = gameObject.tag;

        Level = (Level)System.Enum.Parse(typeof(Level), level);

        GameObject.Find("Level Manager").GetComponent<LevelManager>().setLevel(Level);

        Debug.Log("level set " + Level);

        if (Level.Equals(Level.level1) || Level.Equals(Level.level2) || Level.Equals(Level.level3) || Level.Equals(Level.level4))
        {

            SceneManager.LoadScene("InstructionsScene");

        }

        else
        {

            SceneManager.LoadScene("VAAInstructionScene");

        }

        

        


    }
}
