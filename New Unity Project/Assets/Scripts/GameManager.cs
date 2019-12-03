using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool game_has_ended = false;
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
}
