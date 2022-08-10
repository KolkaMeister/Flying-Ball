using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void StartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().Reset();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
