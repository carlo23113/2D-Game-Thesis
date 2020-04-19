using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public GameObject gameOverCanvas;
    public GameObject panel_pause;
    private PlayerStatusUI playerStatusUI;
    PlayerStatus playerStatus = new PlayerStatus();
    private int health;
    private void Start()
    {
        Time.timeScale = 1;
        
        health = playerStatus.Health;
    }

    public void GameOVer()
    {
        
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Pause()
    {
        panel_pause.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        panel_pause.SetActive(false);
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
