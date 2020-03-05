using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    public static int score = 0;
    public GameObject triviaCanvas;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
       
        if (score >= 1)
        {
            triviaCanvas.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
