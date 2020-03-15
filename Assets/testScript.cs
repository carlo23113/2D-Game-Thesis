using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class testScript : MonoBehaviour
{
    private bool moveRight = false;
    private int speed = 5;
    void Update()
    {
        if(MoveRight)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    public bool MoveRight
    {
        get{return moveRight;}
        set{moveRight = value;}

    }
}
