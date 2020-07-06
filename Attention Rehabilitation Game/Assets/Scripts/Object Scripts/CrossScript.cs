using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossScript : GameObjectScript
{
   

    private void OnMouseDown()
    {
        GameObject[] possible_positions = null;

         if (gameObject.tag.Equals("red_cross"))
         {
             possible_positions = GameObject.FindGameObjectsWithTag("red_circle");
         }

         if (gameObject.tag.Equals("blue_cross"))
         {
             possible_positions = GameObject.FindGameObjectsWithTag("blue_circle");
         }

         if (gameObject.tag.Equals("green_cross"))
         {
             possible_positions = GameObject.FindGameObjectsWithTag("green_circle");
         }

         int ss = Random.Range(0, possible_positions.Length );
        // Vector3 v = possible_positions[index].transform.position;
        Vector3 v = possible_positions[0].transform.position;


        GameObject.Find("Sprite Manager").GetComponent<ObjectSpawner>().Reposition(v);

        //Destroy(gameObject);
        //gameObject.SetActive(false);

    }
}
