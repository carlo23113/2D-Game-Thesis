
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

    public void onProceed()
    {
        SceneManager.LoadScene("exam");
    }

    public void onDecline()
    {
        
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
