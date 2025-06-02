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
    [SerializeField] private ParticleSystem ps;
    [SerializeField] private AudioClip particles;
    [SerializeField] private AudioClip waterFlow;
    public Animator anim;
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
        if (ps == null)
        {
            Debug.LogError("Particle System reference is null!");
            return;
        }

        anim = GetComponent<Animator>();

        ps = GetComponentInChildren<ParticleSystem>();

        anim.ResetTrigger("Completed");

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
        if (correctedPipes == totalPipes)
        {
            if (sceneName == "PipeLevel1")
            {
                anim.SetTrigger("Completed");
            }
            else if (sceneName == "PipeLevel2")
            {
                anim.SetTrigger("CompletedLevel2");
            }
            else if (sceneName == "PipeLevel3")
            {
                anim.SetTrigger("CompletedLevel3");
            }

            Debug.Log("You Win");

        }
    }

    public void PipesDisappear()
    {

        // Start a coroutine to wait for the particle system to stop
        StartCoroutine(WaitForParticlesToStop());
    }

    private IEnumerator WaitForParticlesToStop()
    {
        // Wait until the particle system is no longer playing
        while (!ps.isStopped)
        {
            yield return null; // Wait for the next frame
        }

        // Activate the YouWinPopUp GameObject
        YouWinPopUp.SetActive(true);
        Debug.Log("You Win popup activated after particles stopped.");
    }
    public void IncorrectMove()
    {
        correctedPipes--;
    }
}