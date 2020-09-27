using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int level;
    public GameObject gameOverCanvas;
    public GameObject panel_pause;
    private PlayerStatusUI playerStatusUI;
    PlayerStatus playerStatus = new PlayerStatus();
    private int health;


    private void Start()
    {
        Time.timeScale = 1;
        
        health = playerStatus.Health;

        if (gameOverCanvas)
        {
            Debug.Log("none");
        }

        if (panel_pause)
        {
            Debug.Log("none");
        }

        if(level == 1)
        {
            FindObjectOfType<sound_manager>().Stop("bgm1");
            FindObjectOfType<sound_manager>().Stop("bgm2");
            FindObjectOfType<sound_manager>().Stop("bgm3");
            FindObjectOfType<sound_manager>().Play("bgm1");
            //FindObjectOfType<sound_manager>().Stop("bgm1");
        }

        if(level == 2)
        {
            FindObjectOfType<sound_manager>().Stop("bgm1");
            FindObjectOfType<sound_manager>().Stop("bgm3");
            FindObjectOfType<sound_manager>().Stop("bgm2");
            FindObjectOfType<sound_manager>().Play("bgm2");
        }

        if(level == 3)
        {
            FindObjectOfType<sound_manager>().Stop("bgm1");
            FindObjectOfType<sound_manager>().Stop("bgm2");
            FindObjectOfType<sound_manager>().Stop("bgm3");
            FindObjectOfType<sound_manager>().Play("bgm3");
        }
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        FindObjectOfType<sound_manager>().Play("select");
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        FindObjectOfType<sound_manager>().Play("select");
        Time.timeScale = 1;
        panel_pause.SetActive(false);
    }

    public void Exit()
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene("MenuScene");
    }

    public void Replay()
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
