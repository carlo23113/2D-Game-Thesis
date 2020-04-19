using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
   public GameObject[] popUps;
   private int popUpIndex;
   [SerializeField] private RightButton btn_right;
   [SerializeField] private LeftButton btn_left;
   [SerializeField] private JumpButton btn_jump;
   [SerializeField] private PlayerMovement player;

   void Start()
   {
       player.JumpForce = 0;
   }
   void Update()
   {
       for(int i = 0; i<popUps.Length; i++)
       {
           if( i == popUpIndex)
           {
               popUps[i].SetActive(true);
           }
           else
           {
               popUps[i].SetActive(false);
           }
       }

       if(popUpIndex == 0)
       {
           if(btn_left.Pressed || btn_right.Pressed)
           {
               popUpIndex++;
           }
           else if(popUpIndex==1)
           {
              if(btn_jump.Pressed)
              {
                  player.JumpForce = 7;
                  Debug.Log(player.JumpForce);
                  popUpIndex++;
              }
           }
           else if(popUpIndex == 2)
           {

           }
       }
   }
}
