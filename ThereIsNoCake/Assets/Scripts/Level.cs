using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    AudioSource audioLevel;
    public AudioClip gameOverClip;
    public AudioClip levelClearClip;


    public static Level instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
           instance = this;

        audioLevel = GetComponent<AudioSource>();
    }
    
    public void GameOver()
    {
        PlayClip(gameOverClip);
    }

    public void LevelClear()
    {
        PlayClip(levelClearClip);
    }

    void PlayClip(AudioClip clip)
    {
        audioLevel.Stop();
        audioLevel.loop = false;
        audioLevel.clip = clip;
        audioLevel.Play();
    }

    public void RestartLevel()
    {
        Invoke("LoadLevel", 2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
