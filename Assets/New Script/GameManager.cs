using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
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
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
      
    }

}
