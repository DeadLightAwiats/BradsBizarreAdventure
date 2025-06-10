using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject deathScreen;
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        deathScreen.SetActive(false); // Ensure death screen is hidden at start
        pauseScreen.SetActive(false); // Ensure pause screen is hidden at start
    }
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
        if (playerHealth.currentHealth == 0)
        {
            deathScreen.SetActive(true);
            Time.timeScale = 0; // Pause the game when player dies
        }
        else if (playerHealth.currentHealth > 0 && deathScreen.activeInHierarchy)
        {
            deathScreen.SetActive(false); // Hide death screen if player is alive
            Time.timeScale = 1; // Resume the game if player is alive
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
