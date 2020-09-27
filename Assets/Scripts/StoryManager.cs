using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        index = 0;

        if(panels.Length > 0)
        {
            foreach(GameObject g in panels)
            {
                g.SetActive(false);
            }

            DisplayPanel();
            
        } else
        {
            Debug.Log("No Game object assigned");
        }

        //StartCoroutine(ChangePanel());
    }

    private void DisplayPanel()
    { 
        if (index == panels.Length - 1)
        {
            NextScene();
        }
        panels[index].SetActive(true);
        StartCoroutine(ChangePanel());
    }

    IEnumerator ChangePanel()
    {   
        yield return new WaitForSeconds(4f);

        panels[index].SetActive(false);
        index++;
        DisplayPanel();
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
