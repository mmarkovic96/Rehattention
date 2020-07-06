using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    float startTime = 121f;
    float currentTime = 0f;

 
    [SerializeField] Text timer;

    // Start is called before the first frame update
    void Start()
    {

        currentTime = startTime;
        
    }

    public bool GameOver()
    {
        return currentTime<=0;
    }

    // Update is called once per frame
    void Update()
    {

        currentTime -= 1 * Time.deltaTime;

        int l = (int)(currentTime % 60);

        string seconds = (l < 10 ) ? "0" + l.ToString() : l.ToString();

        timer.text = "Time: " + ((int)(currentTime/60)).ToString() + ":" + seconds;
        
    }
}
