using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void openGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void openSettings()
    {
        Debug.Log("openSettings");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
