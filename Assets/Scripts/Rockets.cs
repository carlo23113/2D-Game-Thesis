using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rockets : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private GameObject target;
    private float moveSpeed;
    private Vector3 directionToTarget;

  

    void Start()
    {


        target = GameObject.FindGameObjectWithTag("Target");
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(1f, 10f);
        
    }

    void Update()
    {
        MoveRockets();
    }

   void MoveRockets()
    {
        if (target)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed, directionToTarget.y * moveSpeed);
           
        } else
        {
            rb.velocity = Vector3.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
       

        if (c.gameObject.tag == "Player")
        {
            FindObjectOfType<sound_manager>().Play("explosion");
            c.gameObject.GetComponent<Health>().health--;
            DisableMovement(c.gameObject);
                
        }
    }

    private IEnumerator DoNotMove(GameObject g)
    {
        Destroy(gameObject);
        g.GetComponent<PlayerMovement>().enabled = true;
        yield return new WaitForSeconds(2f);
        
        
    }

    void DisableMovement(GameObject g)
    {
        g.GetComponent<PlayerMovement>().enabled = false;
        
        StartCoroutine(DoNotMove(g));
        
    }
}
