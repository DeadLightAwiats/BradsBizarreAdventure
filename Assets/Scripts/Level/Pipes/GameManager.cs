using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using System.Security.Cryptography.X509Certificates;

public class GameManager : MonoBehaviour
{
    public GameObject waterPipes;
    [SerializeField] private GameObject PipeHolder;
    [SerializeField] private GameObject[] wateredPipes;
    [SerializeField] private GameObject[] pipes;
    [SerializeField] private GameObject YouWinPopUp;
    public int correctedPipes = 0;
    public int totalPipes = 0;
    public int totalWaterPipes = 0;


    void Start()
    {
        if (waterPipes == null)
        {
            Debug.LogError("Water Pipes reference is null!");
            return;
        }

        if (wateredPipes.Length <= 0)
        {
            Debug.LogError("No watered pipes attached.");
            return;
        }

        if (pipes.Length <= 0)
        {
            Debug.LogError("No pipes attached.");
            return;
        }

        if (YouWinPopUp == null)
        {
            Debug.LogError("You win popup reference is null!");
            return;
        }
        

       


       

        PipeHolder.SetActive(true);
        YouWinPopUp.SetActive(false);
        waterPipes.gameObject.SetActive(false);

        Debug.Log($"Water Pipes active state start: {waterPipes.gameObject.activeSelf}");

        totalWaterPipes = waterPipes.transform.childCount;

        totalPipes = PipeHolder.transform.childCount;
        pipes = new GameObject[totalPipes];
        for (int i = 0; i < totalPipes; i++)
        {
            pipes[i] = PipeHolder.transform.GetChild(i).gameObject;
        }
    }
    public void CorrectedMove()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        correctedPipes++;
        if(correctedPipes  == totalPipes)
            YouWinPopUp.SetActive(true);
    }

    public void IncorrectMove()
    {
        correctedPipes--;
    }
}