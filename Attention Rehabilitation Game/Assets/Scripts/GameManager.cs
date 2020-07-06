using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<TimerScript>().GameOver())
        {
            GameOver();
        }

    }

    void IncrementScore()
    {
        score++;
    }

    void GameOver()
    {
        
        SceneManager.LoadScene("GameOverScene");
        
    }

   
}
