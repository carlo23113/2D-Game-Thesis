using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D c)
    {
        

        if(c.gameObject.tag == "Player")
        {
            if (c.GetComponent<Health>().health < 1)
            {
                FindObjectOfType<GameManager>().GameOver();
            } else
            {
                c.gameObject.GetComponent<Health>().health--;
                c.gameObject.transform.position = new Vector3(c.gameObject.transform.position.x - 5, -3, 0);
                FindObjectOfType<sound_manager>().Play("hit");
                DisableMovement(c.gameObject);
            }
            

        } 
    }

    private IEnumerator DoNotMove(GameObject g)
    {

        yield return new WaitForSeconds(2f);
        g.GetComponent<PlayerMovement>().enabled = true;
        
    }

    void DisableMovement(GameObject g)
    {
        g.GetComponent<PlayerMovement>().enabled = false;

        StartCoroutine(DoNotMove(g));

    }
}
