using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //If Pause screen is active unpause and vise versa
            if (pauseScreen.activeInHierarchy)
                PauseGame(false);
            else
                PauseGame(true);
        }
    }

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

    public void PauseGame(bool Status)
    {
        //if status == true pause.  if status == false unpause
        pauseScreen.SetActive(Status);

        if (Status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

    }
    public void Resume()
    {

        PauseGame(false);
    }
    // Optionally, add a method to stop music from the menu
}
