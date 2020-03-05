using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private float moveSpeed;
    private float dirX;
    private bool facingRight = true;
    private Vector3 localScale;
    public GameManager gameManager;
    public float velocity = 1;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
        moveSpeed = 5f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            //jump
            rb.velocity = Vector2.up * velocity;
        }

        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;

        if (Mathf.Abs(dirX) > 0 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);
        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    private void LateUpdate()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("pipe"))
        {
            gameManager.GameOVer();
        }
        
        
    }
}
