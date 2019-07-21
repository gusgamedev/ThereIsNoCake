using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            player.canMove = false;
            player.anim.PlayerRun(0);
            player.audioPlayer.LevelCompleteFx();
            Invoke("NextLevel", 1f);
        }
    }

    private void NextLevel()
    {
        int maxScenes = SceneManager.sceneCountInBuildSettings;
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene > maxScenes-1)
            SceneManager.LoadScene("Menu");
        else
            SceneManager.LoadScene(nextScene);
    }
}
