using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int scenenum;
    bool game_has_ended = false;

    private void Start()
    {
        scenenum = SceneManager.GetActiveScene().buildIndex;
    }
    public void EndGame()
    {
        if (!game_has_ended)
        {
            game_has_ended = true;
            Restart();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        game_has_ended = false;
    }

    public void LevelUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
