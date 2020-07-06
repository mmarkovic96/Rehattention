using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InstructionsScript : MonoBehaviour
{

    Canvas canvas;

    public Canvas[] steps;

    [SerializeField]
    Text goal, text1, text2;


    string[] level1_text1 = new string[4]{ "Click on the red cross.", "Now click on the blue cross.", "Good job! Click on the blue cross.", "Good job! Ready to play?"};
    string[] level1_text2 = new string[3]{ "The next cross will be displayed at the position of the red circle.",
        "The cross will now be displayed at the position of the blue circle in the next step.", "Next cross position is the position of the blue circle."};

    string[] level2_text1 = new string[4] { "Click on the red cross.", "Now click on the blue cross.", "Good job! Click on the blue cross.", "Good job! Ready to play?" };
    string[] level2_text2 = new string[3]{ "The next cross will be displayed at the position of one of the two red circles.",
        "The next cross will be displayed at the position of one of the two blue circles.", "The next cross will be displayed at the position of one of the two blue circles."};

    string[] level3_text1 = new string[4] { "Click on the green cross.", "Now click on the blue cross.", "Now click on the red cross.", "Good job! Ready to play?" };
    string[] level3_text2 = new string[3]{ "The next cross will be displayed at the position of the green circle.",
        "The cross will now be displayed at the position of the blue circle in the next step.", "The next cross will be displayed at the position of the red circle."};

    string[] level4_text1 = new string[4] { "Click on the green cross.", "Now click on the blue cross.", "Now click on the red cross.", "Good job! Ready to play?" };
    string[] level4_text2 = new string[3]{ "The next cross will be displayed at the position of one of the two green circles.",
        "The next cross will be displayed at the position of one of the two blue circles.", "The next cross will be displayed at the position of one of the two red circles."};

    string[] level_text1;
    string[] level_text2;

    int count = 0;

    [SerializeField]
    GameObject playButton, instructionsButton;

    // Start is called before the first frame update
    void Start()
    {

        Level level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

        //Level level = Level.level4;

        switch (level){
            case Level.level1:
                canvas = GameObject.FindGameObjectWithTag("level1").GetComponent<Canvas>();
                level_text1 = level1_text1;
                level_text2 = level1_text2;
                break;
            case Level.level2:
                canvas = GameObject.FindGameObjectWithTag("level2").GetComponent<Canvas>();
                level_text1 = level2_text1;
                level_text2 = level2_text2;
                break;
            case Level.level3:
                canvas = GameObject.FindGameObjectWithTag("level3").GetComponent<Canvas>();
                level_text1 = level3_text1;
                level_text2 = level3_text2;
                break;
            case Level.level4:
                canvas = GameObject.FindGameObjectWithTag("level4").GetComponent<Canvas>();
                level_text1 = level4_text1;
                level_text2 = level4_text2;
              
                break;
            default:
                return;

        }

        steps = canvas.GetComponentsInChildren<Canvas>(true).Where(go => !go.gameObject.Equals(canvas.gameObject)).ToArray<Canvas>();

        steps[count].gameObject.SetActive(true);
        text1.text = level_text1[count];
        text2.text = level_text2[count];

    }


    public void Instructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("InstructionsScene");
    }


    public void NextStep()
    {
        steps[count].gameObject.SetActive(false);
    
        count = (count == steps.Length-1) ? 0 : ++count;
        steps[count].gameObject.SetActive(true);
        text1.text = level_text1[count];
        text2.text = level_text2[count];

    }

    public void LastStep()
    {
        steps[count].gameObject.SetActive(false);
        count++;
        steps[count].gameObject.SetActive(true);
        text1.text = level_text1[count];
        text2.text = null;

        playButton.SetActive(true);
        instructionsButton.SetActive(true);

    }

    public void Play() {

        Debug.Log("in play");
        UnityEngine.SceneManagement.SceneManager.LoadScene("VisualAttGame");

    }

}
