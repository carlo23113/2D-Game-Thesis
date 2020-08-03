using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Video;

public class LearningPhaseOne : MonoBehaviour
{
    public GameObject[] information;
    public GameObject button;
    private int index = 0;

    private void Start()
    {
        for(int i = 0; i < information.Length; i++)
        {
            information[i].SetActive(false);
        }
    }

    public void DisplayInformation()
    {
        if(button.transform.childCount > 0)
        {
            information[index].SetActive(true);
        } else
        {
            Debug.Log("Nothing to show yet");
        }
    }

    public void Next()
    {
        information[index].SetActive(false);
        index++;
        if(index == information.Length)
        {
            index = 0;
        }
        DisplayInformation();
    }

    public void CloseInformation()
    {
        information[index].SetActive(false);
    }
}
