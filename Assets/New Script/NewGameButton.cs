using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    [SerializeField]private string scene;
    public void newGame()
    {
        SceneManager.LoadScene(scene);
    }
}
