using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public GameObject youwin;

    float[] rotations = { 0.0f, 90.0f, 180.0f, 270.0f };

    [SerializeField] private float correctRotation;
    [SerializeField] private float currentRotation;
    [SerializeField] private bool isPlaced = false;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip rotate;

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0.0f, 0.0f, rotations[rand]);
        currentRotation = Mathf.Round(transform.eulerAngles.z / 90) * 90;
        

        if (currentRotation == correctRotation)
        {
            isPlaced = true;  
            gameManager.CorrectedMove();
        }
        else
        {
            isPlaced = false;
        }
    }

    private void OnMouseDown()
    {
            if (!youwin.activeInHierarchy && !gameManager.waterPipes.activeInHierarchy && gameManager.correctedPipes != gameManager.totalPipes)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, 90.0f));
                currentRotation = Mathf.Round(transform.eulerAngles.z / 90) * 90;
        }
            if (currentRotation == correctRotation)
            {
                if (!isPlaced)
                {
                    isPlaced = true;
                    gameManager.CorrectedMove();
                }
            }
            else
            {
                if (isPlaced)
                {
                    isPlaced = false;
                    gameManager.IncorrectMove();
                }
            }
    }
}