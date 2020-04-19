using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogOne : MonoBehaviour
{
    [SerializeField] private GameObject firstDialog,sentence_1,sentence_2;
    private int i = 0;

    public void NextSentence()
    {
         if(i>0)
         {
            firstDialog.SetActive(false);
         }

        sentence_1.SetActive(false);
        sentence_2.SetActive(true);
        i = 1;

    }

    public void GotIt()
    {
       
    }
}
