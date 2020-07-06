using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectScript : MonoBehaviour
{

    public static IList<GameObject> gameObjects = new List<GameObject>();

    private float min_X = -2.3f, max_X = 2.3f;

    private float min_Y = -4.2f, max_Y = 4.2f;


    // Start is called before the first frame update
    void Start()
    {
        //gameObjects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomPosition()
    {

        float x, y;

        x = Random.Range(min_X, max_X);
        y = Random.Range(min_Y, max_Y);
        Vector3 position = new Vector3(x, y, 0);

        transform.position = position;
    }
}

