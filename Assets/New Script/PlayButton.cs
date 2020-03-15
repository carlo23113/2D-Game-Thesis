using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panel2;

    public void buttonPlay()
    {
        panel2.SetActive(true);
    }
}
