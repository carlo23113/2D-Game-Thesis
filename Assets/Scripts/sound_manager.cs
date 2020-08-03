using UnityEngine.Audio;
using UnityEngine;

public class sound_manager : MonoBehaviour
{
    public static sound_manager _instance;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        } else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
} // end of class
