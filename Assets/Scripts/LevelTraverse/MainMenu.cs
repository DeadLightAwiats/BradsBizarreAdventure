using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level_01()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {

        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Exits play mode in editor
#endif
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void SettingsButton()
    {
        SceneManager.LoadSceneAsync(2);
    }
    // Optionally, add a method to stop music from the menu
}
