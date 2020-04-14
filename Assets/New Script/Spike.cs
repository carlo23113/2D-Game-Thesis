using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    PlayerStatus playerStatus = new PlayerStatus();
    [SerializeField]private PlayerStatusUI playerUI;
    [SerializeField]private GameManager gameManager;
    
    void OnCollisionEnter2D(Collision2D other){
        int playerHealth = playerStatus.Health;
        if(other.gameObject.CompareTag("Player")){
           playerStatus.Health = playerHealth-=1;
           playerUI.NumberOfHealth = playerHealth;
           
           if(playerHealth == 0)
           {
               gameManager.GameOVer();
           }
        }
    }
}
