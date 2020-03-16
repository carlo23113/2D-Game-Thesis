using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float direction;
    [SerializeField]private float speed;

    public float Direction
    {
        get{return direction;}
        set{direction = value;}
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBody.velocity = new Vector2(direction * speed, rigidBody.velocity.y);
    }

    
}
