using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class VAAInstructionsScript : MonoBehaviour
{

    Canvas canvas;

    public Canvas[] steps;

    Level level;

    int count = 0;

    [SerializeField]
    GameObject text;


    private void Awake()
    {
        level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();
        
        //GameObject.Find("Level Manager").GetComponent<LevelManager>().setLevel(level);
    }


    // Start is called before the first frame update
    void Start()
    {

        if(level.Equals(Level.level5)|| level.Equals(Level.level6))
        {
            canvas = GameObject.FindGameObjectWithTag("level5").GetComponent<Canvas>();
        }
        else
        {
            canvas = GameObject.FindGameObjectWithTag("level7").GetComponent<Canvas>();
        }

        steps = canvas.GetComponentsInChildren<Canvas>(true).Where(go => !go.gameObject.Equals(canvas.gameObject)).ToArray<Canvas>();

        steps[count].gameObject.SetActive(true);
        

    }

    public void NextStep()
    {

        steps[count].gameObject.SetActive(false);
        count++;
        steps[count].gameObject.SetActive(true);

        if (steps[count].tag.Equals("last"))
        {
            if(level.Equals(Level.level6)|| level.Equals(Level.level8))
            {
                text.SetActive(true);

            }
            else
            {
                //canvas.GetComponent<Text>().gameObject.SetActive(false);
                text.SetActive(false);
            }
        }
    }

    public void StepBack()
    {

        steps[count].gameObject.SetActive(false);
        count--;
        steps[count].gameObject.SetActive(true);
        text.SetActive(false);


    }

    public void PlaySound()
    {

        AudioManager am = (AudioManager)FindObjectOfType(typeof(AudioManager));

        am.Play(steps[count].tag);


    }

    public void Play()
    {
        Debug.Log("in play");
        UnityEngine.SceneManagement.SceneManager.LoadScene("VisAuAttGame");

    }
}
