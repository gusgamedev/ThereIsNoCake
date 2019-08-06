using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource audioMenu;
    public AudioClip startClip;

    private void Start()
    {
        audioMenu = GetComponent<AudioSource>();
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Help");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToGame()
    {
        audioMenu.Stop();
        audioMenu.loop = false;
        audioMenu.clip = startClip;
        audioMenu.Play();
        Invoke("StartGame", 2.1f);
    }

    void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
