using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitTutorial : MonoBehaviour
{
    private string scene = "MenuScene";
    void OnTriggerEnter2D(Collider2D e)
    {
        SceneManager.LoadScene(scene);
    }
}
