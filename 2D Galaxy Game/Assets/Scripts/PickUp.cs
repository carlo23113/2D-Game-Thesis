﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    private inventory inventory;
    public GameObject itemButton;

    private void Start()
    { 
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    //item can be added in inventory
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    ScoreScript.score += 1;
                    break;
                }
            }
        }
    }
}
