
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class QuestionAndAnswer : MonoBehaviour
{
    public GameObject confirmation;

    private void Start()
    {
        confirmation.SetActive(false);
    }

    public void onProceed(string stage)
    {
        FindObjectOfType<sound_manager>().Play("select");
        SceneManager.LoadScene(stage);
    }

    public void onDecline()
    {
        FindObjectOfType<sound_manager>().Play("select");
        confirmation.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            confirmation.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            confirmation.SetActive(false);
        }
    }
}
