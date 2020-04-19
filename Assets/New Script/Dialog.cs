using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject[] spriteDisplay;
    public string[] sentences;
    private int index;
    public GameObject continueBtn, obj;
    [SerializeField]private float typingSpeed;

    void Start()
    {
        StartCoroutine(Type());
        continueBtn.SetActive(false);
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueBtn.SetActive(true);
        }

      
    }

    IEnumerator Type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        continueBtn.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

          if(index > sentences.Length )
        {
            EndSentence();
            return;
        }
    }

    public void EndSentence()
    {
        obj.SetActive(false);
    }
}
