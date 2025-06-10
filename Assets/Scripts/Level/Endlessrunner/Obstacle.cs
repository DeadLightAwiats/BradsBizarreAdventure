using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Health playerHealth;
    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        if (playerHealth == null)
        {
            Debug.LogError("Player Health component not found!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "border")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "Player")
        {
            

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                Debug.Log("Player hit by obstacle, health reduced.");
            }
            if(playerHealth.currentHealth <= 0)
            {
                Debug.Log("Player has died.");
                Destroy(collision.gameObject);
            }
        }
    }

}
