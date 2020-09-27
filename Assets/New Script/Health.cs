using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite astronaut;
    public Sprite empty;

    // Update is called once per frame
    void Update()
    {

        if(health == 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        if(health > numberOfHearts)
        {
            health = numberOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].color = new Color(255,255,255,1);
            } else
            {
                hearts[i].color = new Color(1,1,1,0);
            }
            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }

   
}
