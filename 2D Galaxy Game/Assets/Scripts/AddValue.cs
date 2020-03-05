using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddValue : MonoBehaviour

{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemScore.score++;

        
    }
}
