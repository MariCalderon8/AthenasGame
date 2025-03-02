using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    public AudioSource audioSource;
    public AudioClip backgroundMusic;
    public string[] scenesWithMusic;

    private bool isPlayingMusic = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);  
        }
    }

    void Start()
    {
        PlayBackgroundMusic();
    }

    void OnLevelWasLoaded(int level)
    {
        PlayBackgroundMusic();
    }

    void PlayBackgroundMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Comprobar si la música debe sonar en esta escena
        if (Array.Exists(scenesWithMusic, scene => scene == currentScene))
        {
            if (!isPlayingMusic)
            {
                audioSource.clip = backgroundMusic;
                audioSource.loop = true;
                audioSource.Play();
                isPlayingMusic = true;
            }
        }
        else
        {
            // Detener la música si no está en las escenas deseadas
            if (isPlayingMusic)
            {
                audioSource.Stop();
                isPlayingMusic = false;
            }
        }
    }
}