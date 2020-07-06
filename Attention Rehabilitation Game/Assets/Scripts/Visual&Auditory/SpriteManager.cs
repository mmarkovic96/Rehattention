using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{

    public static SpriteManager manager;

    [SerializeField]
    private GameObject bird, bell;

    [SerializeField]
    private GameObject chicken, pigeon, sparrow;

    [SerializeField]
    private AudioSource sound;

    [SerializeField]
    private AudioClip level6_background, level8_background;

    private float min_X = -1.9f, max_X = 1.9f;

    private float min_Y = -4.2f, max_Y = 3.8f;

    Vector3 position;

    IList<GameObject> gameObjects = new List<GameObject>();

    IList<GameObject> positionedObjects = new List<GameObject>();


    private Level level;

    private float playSound = 4.0f;

    private string lastPlayed;

    private List<string> soundNames;
    private List<string> distractonNames;

    int score = 0;


    void RandomPosition()
    {

        float x, y;

        x = UnityEngine.Random.Range(min_X, max_X);
        y = UnityEngine.Random.Range(min_Y, max_Y);
        position = new Vector3(x, y, 0);

        while (CheckForOverlap(position))
        {
            RandomPosition();
        }

        // check for overlapping

        //transform.position = position;


    }


    public void SetUp()
    {


        level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();

       

        

        if (level.Equals(Level.level5) || level.Equals(Level.level6))
        {

            RandomPosition();
            bird = Instantiate(bird, position, Quaternion.identity);
            gameObjects.Add(bird);
            positionedObjects.Add(bird);


            RandomPosition();
            bell = Instantiate(bell, position, Quaternion.identity);
            gameObjects.Add(bell);
            positionedObjects.Add(bell);

            if (level.Equals(Level.level6))
            {
                sound.clip = level6_background;
                sound.loop = true;
                sound.Play();
                
            }



        }


        else
        {

            RandomPosition();
            chicken = Instantiate(chicken, position, Quaternion.identity);
            gameObjects.Add(chicken);
            positionedObjects.Add(chicken);


            RandomPosition();
            pigeon = Instantiate(pigeon, position, Quaternion.identity);
            gameObjects.Add(pigeon);
            positionedObjects.Add(pigeon);

            RandomPosition();
            sparrow = Instantiate(sparrow, position, Quaternion.identity);
            gameObjects.Add(sparrow);
            positionedObjects.Add(sparrow);

            if (level.Equals(Level.level8))
            {
                sound.clip = level8_background;
                sound.loop = true;
                sound.Play();

            }


        }

        AudioManager am = (AudioManager)FindObjectOfType(typeof(AudioManager));
        //GameObject.Find("Audio Manager").GetComponent<AudioManager>();

        soundNames = am.getSounds(level);
        distractonNames = am.getDistractions(level);


    }



    // Start is called before the first frame update
    void Start()
    {

        playSound = 2;
   

    }

 

    void PlaySound(float time)
    {
      
        List<string> playlist = (Random.Range(0, 2) == 0) ? soundNames : distractonNames;

        int i = Random.Range(0, playlist.Count);
       AudioManager am = (AudioManager)FindObjectOfType(typeof(AudioManager));
        lastPlayed = playlist[i];
        am.Play(playlist[i]);
      
        playSound = 4.0f;

    }

   

    // Update is called once per frame
    void Update()
    {
        playSound -= 1 * Time.deltaTime;

        if (playSound <= 0)
        {
            PlaySound(0);
        }
    }

    public void Reposition(string tag)
    {

        AudioManager am = (AudioManager)FindObjectOfType(typeof(AudioManager));
        am.Stop(lastPlayed);

        if (tag.Equals(lastPlayed))
        {
            score++;
        }

        positionedObjects.Clear();
        float x, y;



        for (int i = 0; i < gameObjects.Count; i++)
        {

            RandomPosition();
           
            gameObjects[i].transform.position = position;
            positionedObjects.Add(gameObjects[i]);
        }

       
        playSound = 2;
    }


    public bool CheckForOverlap(Vector3 position)
    {

        float width, height;

        float left, right, up, down;

        for (int i = 0; i < positionedObjects.Count; i++)
        {
            width = positionedObjects[i].GetComponent<SpriteRenderer>().bounds.size.x;
            height = positionedObjects[i].GetComponent<SpriteRenderer>().bounds.size.y;


            left = positionedObjects[i].transform.position.x - width;
            right = positionedObjects[i].transform.position.x + width;
            up = positionedObjects[i].transform.position.y + height;
            down = positionedObjects[i].transform.position.y - height;


            if (position.x >= left && position.x <= right)
            {
                if (position.y >= down && position.y <= up)
                {
                    return true;
                    //overlapping
                }

            }
        }

        return false;



    }
}
