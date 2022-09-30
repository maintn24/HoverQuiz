using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverMenu : MonoBehaviour
{
    public UnityEngine.GameObject GameoverUI;

    bool GameEnded = false;

    public void EndGame()
    {
        if (GameEnded == false)
        {
            GameEnded = true;

            //Set active try again ui
            GameoverUI.SetActive(true);
            Debug.Log("Over");
            //Invoke("GameOver", TryAgainDelayTime);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
