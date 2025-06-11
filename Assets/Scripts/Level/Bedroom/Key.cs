using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public GameObject Popup;
    private bool playerInTrigger = false;
    public static bool HasKey { get; private set; } = false; // Static flag

    private void Start()
    {
        Popup.SetActive(false); // Ensure the popup is hidden at start
    }

    private void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Popup.SetActive(false); // Hide the popup after collecting the key
            HasKey = true;          // Player now has the key
            Destroy(gameObject);    // Remove the key from the scene
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Popup.SetActive(true); // Show the popup when player enters the trigger
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Popup.SetActive(false); // Hide the popup when player exits the trigger
            playerInTrigger = false;
        }
    }
}