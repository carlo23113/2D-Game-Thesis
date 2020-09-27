using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField]
    private GameObject panel2;

    public void buttonPlay()
    {
        FindObjectOfType<sound_manager>().Play("select");
        panel2.SetActive(true);
    }
}
