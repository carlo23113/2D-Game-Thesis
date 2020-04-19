using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private Rigidbody2D rigidBody;
    private Animator animator;
    [SerializeField]private RightButton btn_right;
    [SerializeField]private LeftButton btn_left;
    [SerializeField]private JumpButton btn_jump;
    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;
    private float idle = 0.0f;
    private float run = 0.5f;
    private float jumpUp = 1.0f;
    private float jumpDown = 1.5f;
    private float facingRight = 1f;
    private bool isJumping;
    private Vector3 direction;

    public float JumpForce
    {
        get
        {
            return jumpForce;
        }
        set
        {
            jumpForce = value;
        }
    }

    void Start(){
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = transform.localScale;
    }

    void FixedUpdate(){
      
        if(btn_right.Pressed){
            MovedForward();
        }
        else if(btn_left.Pressed){
            MovedBackward();
        }
        else {
            Stay();
        }

        if(btn_jump.Pressed){
            
            Jump();
        }

        if(isJumping){
            animator.SetFloat("status",jumpUp);
            animator.SetFloat("status",jumpDown);
        }
        
    }

    private void Stay(){
         rigidBody.velocity = new Vector2(speed * idle, rigidBody.velocity.y);
         animator.SetFloat("status", idle);
    }
    private void MovedForward(){
        
            rigidBody.velocity = new Vector2(speed * facingRight, rigidBody.velocity.y);
            direction.x = facingRight;
            transform.localScale = direction;
            animator.SetFloat("status", run);
        
    }

    private void MovedBackward(){
        
            rigidBody.velocity = new Vector2(speed * -facingRight, rigidBody.velocity.y);
            direction.x = -facingRight;
            transform.localScale = direction;
            animator.SetFloat("status", run);
    }

    private void Jump(){
         
        isJumping = true;
        
        rigidBody.velocity = Vector2.up * jumpForce;
        
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Ground")){
            isJumping = false;
            animator.SetFloat("status",idle);
            rigidBody.velocity = Vector2.zero;
            
        }
    }
}
