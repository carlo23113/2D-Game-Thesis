using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sound_manager : MonoBehaviour
{
    public static sound_manager _instance;

    private bool retakeOnce = true;
    
    public bool RetakeOnce
    {
        get { return retakeOnce; }
        set { retakeOnce = value;  }
    }
    
    public Sound[] sounds;

    private void Awake()
    {
        MakeSingleton();

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("bgm1");
    }

    private void Update()
    {
        if(!SceneManager.GetActiveScene().name.Equals("level_three_test"))
        {
            retakeOnce = true;
        }
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

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null) { return; }
        s.source.Stop();
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null) { return; }
        s.source.Play();
    }
} // end of class
