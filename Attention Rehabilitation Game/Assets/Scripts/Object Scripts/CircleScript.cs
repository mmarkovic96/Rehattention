using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : GameObjectScript
{
    private void OnMouseDown()
    {

        RandomPosition();

        GameObject.Find("Sprite Manager").GetComponent<ObjectSpawner>().Reposition(transform.position);
    }
}
