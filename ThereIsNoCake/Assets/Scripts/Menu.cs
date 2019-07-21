using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("Level01");
    }
}
