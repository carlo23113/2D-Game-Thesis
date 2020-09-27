using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    [SerializeField]private string scene;
    public void newGame()
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(scene);
    }
}
