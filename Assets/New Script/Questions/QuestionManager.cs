
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Random = System.Random;
using Random2 = UnityEngine.Random;
public class QuestionManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private int index = 0;
    private Question currentQuestion;

    private TextMeshProUGUI questionText, btnA, btnB, btnC, btnD;

    [SerializeField]
    private GameObject multipleChoicePanel, trueOrFalsePanel;

    [SerializeField]
    private GameObject correctPanel, incorrectPanel;

    void Start()
    {
        multipleChoicePanel.SetActive(false);
        trueOrFalsePanel.SetActive(false);
        correctPanel.SetActive(false);
        incorrectPanel.SetActive(false);

        if(unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        GetTypeOfQuestion();
        
    }

    void SetCurrentQuestion()
    {
        //int randomQuestionIndex = Random2.Range(0, unansweredQuestions.Count);
        //currentQuestion = unansweredQuestions[randomQuestionIndex];
        //Debug.Log(currentQuestion.question+" "+currentQuestion.clueType);
        //unansweredQuestions.RemoveAt(randomQuestionIndex);
        if(index > questions.Length - 1)
        {
            Debug.Log("GameOver");
        } else
        {
            ShuffleQuestion(questions);
            currentQuestion = questions[index];
        }
        
    }

    void GetTypeOfQuestion()
    {
        if (currentQuestion.clueType.Equals("multiple"))
        {
            multipleChoicePanel.SetActive(true);
            questionText = multipleChoicePanel.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            questionText.text = currentQuestion.question;

            string[] answerOptions = Shuffle(currentQuestion.answerOptions);

            btnA = multipleChoicePanel.gameObject.transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
            btnB = multipleChoicePanel.gameObject.transform.GetChild(2).GetChild(1).GetComponent<TextMeshProUGUI>();
            btnC = multipleChoicePanel.gameObject.transform.GetChild(3).GetChild(1).GetComponent<TextMeshProUGUI>();
            btnD = multipleChoicePanel.gameObject.transform.GetChild(4).GetChild(1).GetComponent<TextMeshProUGUI>();

            btnA.text = answerOptions[0];
            btnB.text = answerOptions[1];
            btnC.text = answerOptions[2];
            btnD.text = answerOptions[3];


        } else
        {
            trueOrFalsePanel.SetActive(true);
            questionText = trueOrFalsePanel.gameObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            questionText.text = currentQuestion.question;

        }
    }

    string[] Shuffle(string[] array)
    {
        Random rnd = new Random();
        
        for(int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = rnd.Next(0, i + 1);

            string temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
        return array;
    }

    Question[] ShuffleQuestion(Question[] array)
    {
        Random rnd = new Random();

        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = rnd.Next(0, i + 1);

            Question temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
        return array;
    }

    public void buttonIsTrue()
    {
        if(currentQuestion.clueType.Equals("booleans") && currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        } else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void buttonIsFalse()
    {
        if (currentQuestion.clueType.Equals("booleans") && !currentQuestion.isTrue)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
        }
    }

    public void buttonA()
    {
        if (btnA.text.Equals(currentQuestion.correctAnswer)){
            correctPanel.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
        }
    }

    public void buttonB()
    {
        if (btnB.text.Equals(currentQuestion.correctAnswer))
        {
            correctPanel.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
        }
    }

    public void buttonC()
    {
        if (btnC.text.Equals(currentQuestion.correctAnswer))
        {
            correctPanel.SetActive(true);
        } else
        {
            incorrectPanel.SetActive(true);
        }
    }

    public  void buttonD()
    {
        if (btnD.text.Equals(currentQuestion.correctAnswer))
        {
            correctPanel.SetActive(true);
        }
        else
        {
            incorrectPanel.SetActive(true);
        }
    }
}
