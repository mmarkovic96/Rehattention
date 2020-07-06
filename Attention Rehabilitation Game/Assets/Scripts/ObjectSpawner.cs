using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public static ObjectSpawner instance;

    [SerializeField]
    private GameObject green_Circle, blue_Circle, red_Circle;

    [SerializeField]
    private GameObject green_X, blue_X, red_X;

    private GameObject activeCross;

    private float min_X = -1.9f, max_X = 1.9f;

    private float min_Y = -4.4f, max_Y = 3.8f;

    Vector3 position;


    IList<GameObject> gameObjects = new List<GameObject>();

    IList<GameObject> positionedObjects = new List<GameObject>();


    //enum Level { two_easy, two_hard, three_easy, three_hard };


    private Level level;

    int i = 1;



    public void SetUp()
    {


        level = GameObject.Find("Level Manager").GetComponent<LevelManager>().getLevel();


        Debug.Log("level is "+ level);


        //level = Level.level1;

        //levels with double circles

        if (level.Equals(Level.level2)|| level.Equals(Level.level4))
        {

            i = 2;

        }

        RandomPosition();
        InstantiateCross(position);

        while (i > 0)
        {

            RandomPosition();
            red_Circle = Instantiate(red_Circle, position, Quaternion.identity);
            gameObjects.Add(red_Circle);
            positionedObjects.Add(red_Circle);


            RandomPosition();
            blue_Circle = Instantiate(blue_Circle, position, Quaternion.identity);
            gameObjects.Add(blue_Circle);
            positionedObjects.Add(blue_Circle);

            if(level.Equals(Level.level3) || level.Equals(Level.level4))
            {

                RandomPosition();
                green_Circle = Instantiate(green_Circle, position, Quaternion.identity);
                gameObjects.Add(green_Circle);
                positionedObjects.Add(green_Circle);

            }

            i--;

        }
        
        

    }


    void PlayTouchSound()
    {
        this.GetComponent<AudioSource>().Play();
    }

    void InstantiateCross(Vector3 pos)
    {

        int i = (level.Equals(Level.level1)|| level.Equals(Level.level2)) ? 2 : 3;

        int cross = UnityEngine.Random.Range(0, i);

        switch (cross)
        {
            case 0:
                activeCross = Instantiate(red_X, pos, Quaternion.identity, red_X.transform.parent);
                break;
            case 1:
                activeCross = Instantiate(blue_X, pos, Quaternion.identity, blue_X.transform.parent);
                break;
            case 2:
                activeCross = Instantiate(green_X, pos, Quaternion.identity, green_X.transform.parent);
                break;
            default:
                activeCross = Instantiate(red_X, pos, Quaternion.identity, red_X.transform.parent);
                break;
        }

        positionedObjects.Add(activeCross);


    }

    void Instantiate()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        //Instantiate();


    }

    // Update is called once per frame
    void Update()
    {

        
    }

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

    public void Reposition(Vector3 pos)
    {

        PlayTouchSound();

        Debug.Log("Reposition method entered ");

        Destroy(activeCross);


        positionedObjects.Clear(); 
        float x, y;

        InstantiateCross(pos);


        for(int i = 0; i < gameObjects.Count; i++)
        {

            RandomPosition();
            

            //while (CheckForOverlap(position))
            //{
            //    RandomPosition();
            //}
            gameObjects[i].transform.position = position;
            positionedObjects.Add(gameObjects[i]);


        }

       


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

            /* width = positionedObjects[i].GetComponent<Collider2D>().bounds.extents.x*2;
             height = positionedObjects[i].GetComponent<Collider2D>().bounds.extents.y*2;
             Vector3 centerpoint = positionedObjects[i].GetComponent<Collider2D>().bounds.center;

             left = centerpoint.x - width;
             right = centerpoint.x + width;
             up = centerpoint.y + height;
             down = centerpoint.y - height;*/


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
