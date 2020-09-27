using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{
    private const string scene ="tutorial_scene";

    public void GoToTutorialScene()
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(scene);
    }
}
