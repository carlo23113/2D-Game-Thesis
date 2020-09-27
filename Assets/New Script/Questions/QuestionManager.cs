
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using Random = System.Random;
using Random2 = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{

    [SerializeField]
    private int level;

    public Question[] questions;
    private static List<Question> unansweredQuestions;
    private int index = 0;
    private Question currentQuestion;

    [SerializeField]
    private Sprite correctTexture, wrongTexture, defaultTexture;

    private TextMeshProUGUI questionText;
    private TextMeshProUGUI btnA, btnB, btnC, btnD;

    [SerializeField]
    private GameObject multipleChoicePanel, trueOrFalsePanel;

    [SerializeField]
    private GameObject gameOverPanel;

    private int score;

    [SerializeField]
    private int maxQuestion, passingScore;

    void Start()
    {
      

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        DefaultSetting();
        ShuffleQuestion(questions);
        SetCurrentQuestion();
        GetTypeOfQuestion();
        
        score = 0;
    }

    private void DefaultSetting()
    {
        multipleChoicePanel.SetActive(false);
        trueOrFalsePanel.SetActive(false);
        gameOverPanel.SetActive(false);

        for(int i = 1; i <= 4; i++)
        {
            multipleChoicePanel.gameObject.transform.GetChild(i).GetComponent<Image>().sprite = defaultTexture;
            multipleChoicePanel.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        for(int i = 1; i<=2; i++)
        {
            trueOrFalsePanel.gameObject.transform.GetChild(i).GetComponent<Image>().sprite = defaultTexture;
            trueOrFalsePanel.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }

        
    }
    void SetCurrentQuestion()
    {
        currentQuestion = questions[index];  
    }

    void GetTypeOfQuestion()
    {
        if (currentQuestion.clueType == "multiple")
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


        } 
        
        if(currentQuestion.clueType.Equals("booleans"))
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
            FindObjectOfType<sound_manager>().Play("correct");
            trueOrFalsePanel.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = correctTexture;
            score++;
        } else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            trueOrFalsePanel.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public void buttonIsFalse()
    {
        if (currentQuestion.clueType.Equals("booleans") && !currentQuestion.isTrue)
        {
            FindObjectOfType<sound_manager>().Play("correct");
            trueOrFalsePanel.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = correctTexture;
            score++;
        }
        else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            trueOrFalsePanel.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public void buttonA()
    {
        if (btnA.text.Equals(currentQuestion.correctAnswer)){
            FindObjectOfType<sound_manager>().Play("correct");
            multipleChoicePanel.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = correctTexture;
            score++;
        }
        else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            multipleChoicePanel.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public void buttonB()
    {
        if (btnB.text.Equals(currentQuestion.correctAnswer))
        {
            FindObjectOfType<sound_manager>().Play("correct");
            multipleChoicePanel.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = correctTexture;
            score++;
        }
        else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            multipleChoicePanel.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public void buttonC()
    {
        if (btnC.text.Equals(currentQuestion.correctAnswer))
        {
            FindObjectOfType<sound_manager>().Play("correct");
            multipleChoicePanel.gameObject.transform.GetChild(3).GetComponent<Image>().sprite = correctTexture;
            score++;
        } else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            multipleChoicePanel.gameObject.transform.GetChild(3).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public  void buttonD()
    {
        if (btnD.text.Equals(currentQuestion.correctAnswer))
        {
            FindObjectOfType<sound_manager>().Play("correct");
            multipleChoicePanel.gameObject.transform.GetChild(4).GetComponent<Image>().sprite = correctTexture;
            score++;
        }
        else
        {
            FindObjectOfType<sound_manager>().Play("wrong");
            multipleChoicePanel.gameObject.transform.GetChild(4).GetComponent<Image>().sprite = wrongTexture;
            RevealCorrectAnswer();
        }

        InteractiveButtons();

        StartCoroutine(ChangeQuestion());
    }

    public void NextQuestion()
    {
        if(index < maxQuestion - 1)
        {
           index++;
            Debug.Log("current Index " + index);
            DefaultSetting();
            SetCurrentQuestion();
            GetTypeOfQuestion();
        } else
        {
            GameOver();
        }

        
    }

    private IEnumerator ChangeQuestion()
    {
        yield return new WaitForSeconds(2f);
        NextQuestion();
    }

    private void RevealCorrectAnswer()
    {
        if (currentQuestion.clueType.Equals("multiple"))
        {
            for(int i = 1; i<=4; i++)
            {
                string text = multipleChoicePanel.gameObject.transform.GetChild(i).GetChild(1).GetComponent<TextMeshProUGUI>().text;

                if (currentQuestion.correctAnswer.Equals(text))
                {
                    multipleChoicePanel.gameObject.transform.GetChild(i).GetComponent<Image>().sprite = correctTexture;
                }
            }
        } else if(currentQuestion.clueType.Equals("booleans"))
        {
            if (currentQuestion.isTrue)
            {
                trueOrFalsePanel.gameObject.transform.GetChild(1).GetComponent<Image>().sprite = correctTexture;
            } else
            {
                trueOrFalsePanel.gameObject.transform.GetChild(2).GetComponent<Image>().sprite = correctTexture;
            }
            
        }

        
    }

    private void InteractiveButtons()
    {
        if (currentQuestion.clueType.Equals("multiple"))
        {
            for (int i = 1; i <= 4; i++)
            {
                multipleChoicePanel.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            for (int i = 1; i <= 2; i++)
            {
                trueOrFalsePanel.gameObject.transform.GetChild(i).GetComponent<Button>().interactable = false;
            }
        }
    }

    private void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverPanel.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        Debug.Log("Player score is " + score);

        switch(level)
        {
            case 1:
                LevelOne();
                break;
            case 2:
                LevelTwoA();
                break;
            case 3:
                LevelTwoB();
                break;
            case 4:
                LevelThree();
                break;
        }
    }

    private void LevelOne()
    {
        if(score < passingScore)
        {
            Debug.Log("Failed");
            FindObjectOfType<sound_manager>().Play("failed");
            string text = "FAILED! \n \n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        } else
        {
            Debug.Log("Passed");
            FindObjectOfType<sound_manager>().Play("passed");
            string text = "PASSED! \n\n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    private void LevelTwoA()
    {
        if (score < passingScore)
        {
            Debug.Log("Failed");
            FindObjectOfType<sound_manager>().Play("failed");
            string text = "FAILED! \n \n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            Debug.Log("Passed");
            FindObjectOfType<sound_manager>().Play("passed");
            string text = "PASSED! \n\n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    private void LevelTwoB()
    {
        if (score < passingScore)
        {
            Debug.Log("Failed");
            FindObjectOfType<sound_manager>().Play("failed");
            string text = "FAILED! \n \n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
        else
        {
            Debug.Log("Passed");
            FindObjectOfType<sound_manager>().Play("passed");
            string text = "PASSED! \n\n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    private void LevelThree()
    {
        if (score < passingScore)
        {
            Debug.Log("Failed");
            FindObjectOfType<sound_manager>().Play("failed");
            string text = "FAILED! \n \n Score: \t" + score;

            bool retakeOnce = sound_manager._instance.RetakeOnce;
            Debug.Log(retakeOnce + " retake");
            if (retakeOnce)
            {
                gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                sound_manager._instance.RetakeOnce = false;

            } else
            {
                gameOverPanel.gameObject.transform.GetChild(1).gameObject.SetActive(true);
                gameOverPanel.gameObject.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            }

            gameOverPanel.gameObject.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;

        }
        else
        {
            Debug.Log("Passed");
            FindObjectOfType<sound_manager>().Play("passed");
            string text = "PASSED! \n\n Score: \t" + score;
            gameOverPanel.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameOverPanel.gameObject.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
        }
    }

    public void Restart()
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextStage(string stage)
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(stage);
    }

    
}
