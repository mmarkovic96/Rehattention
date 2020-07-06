using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedStartScript : MonoBehaviour
{

    public GameObject countdown;

    // Start is called before the first frame update
    void Awake()
    {
        Time.timeScale = 0;
        StartCoroutine("StartDelay");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDelay()
    {
        Time.timeScale = 0;

        float pauseTime = Time.realtimeSinceStartup + 4f;

        while (Time.realtimeSinceStartup < pauseTime)
        {
            yield return 0;
            
        }

        countdown.gameObject.SetActive(false);
        Time.timeScale = 1;

        StartGame();
    }



    void StartGame()
    {
        Level Level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

        if (Level.Equals(Level.level1) || Level.Equals(Level.level2) || Level.Equals(Level.level3) || Level.Equals(Level.level4))
        {

            GameObject.Find("Sprite Manager").GetComponent<ObjectSpawner>().SetUp(); 

        }

        else if (Level.Equals(Level.level5) || Level.Equals(Level.level6) || Level.Equals(Level.level7) || Level.Equals(Level.level8))
        {

            GameObject.Find("Sprite Manager").GetComponent<SpriteManager>().SetUp();

        }

        else
        {
            return;
        }
    }
}
