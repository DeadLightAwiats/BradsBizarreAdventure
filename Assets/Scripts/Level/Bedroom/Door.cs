using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private Key Key; // Reference to the Key script
    private bool playerInTrigger = false;

    private void Start()
    {
        Key = FindObjectOfType<Key>(); // Find the Key script in the scene
        Key.Popup.SetActive(false); // Ensure the popup is hidden at start
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Hallway"); // Load the Hallway scene when player presses E
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key.Popup.SetActive(true); // Show the popup when player enters the trigger
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Key.Popup.SetActive(false);
            playerInTrigger = false;
        }
    }
}