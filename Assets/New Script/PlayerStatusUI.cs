using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusUI : MonoBehaviour
{
    
    [SerializeField]private GameObject[] astronaut;
    private int health;
    private int numberOfHealth;
    public int NumberOfHealth{
        set{
            numberOfHealth = value;
        }
    }
    
    void Start()
    {
        PlayerStatus playerStatus = new PlayerStatus();
        health  = astronaut.Length;
        numberOfHealth = playerStatus.Health;
    }
   
   void Update()
   {
       UpdateUI();
   }
    public void UpdateUI()
    {
      for (int i = 0; i < astronaut.Length; i++)
      {
          if(i < numberOfHealth)
          {
              astronaut[i].SetActive(true);
          }
          else
          {
              astronaut[i].SetActive(false);
          }
      }
    }
}
