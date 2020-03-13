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

        //jump  palitan mo ung Input ng CrossPlatformInput para gumana sa buttons ung jump
        if (Input.GetMouseButtonDown(0))
        { 
            
            rb.velocity = Vector2.up * velocity;
        }

        
        // movement ng player sa pagtakbo
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed; 
        // dirX = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;  palitan mo ung code sa taas ng code na to para maging ung buttons sa canvas ung controls nya


        // for movement animations
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

}
