using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dBox;
    public TextMeshProUGUI dText;

    public bool dialogActive;

    public string[] dialogueLines;
    public int currentLine;
    [SerializeField] private int currentScene;

    public PlayerMovement playerController { get; private set; }

    void Start()
    {
        dBox.SetActive(false);
        playerController = FindObjectOfType<PlayerMovement>();
        if (currentScene == 1)
        {
            dialogActive = true;
            dBox.SetActive(true);
            currentLine = 0;
            if (dialogueLines != null && dialogueLines.Length > 0)
                dText.text = dialogueLines[currentLine];
        }
    }

    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }

        // Move scene change logic outside the input check
        if (!dialogActive && currentScene == 4)
        {
            SceneManager.LoadScene("PipesLvl_05");
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dialogueLines = new string[] { dialogue };
        currentLine = 0;
        dText.text = dialogueLines[currentLine];
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        currentLine = 0;
        if (dialogueLines != null && dialogueLines.Length > 0)
            dText.text = dialogueLines[currentLine];
        if (playerController != null)
            playerController.CanMove = false;
    }

    public void NextLine()
    {
        currentLine++;
        if (dialogueLines == null || currentLine >= dialogueLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            if (playerController != null)
                playerController.CanMove = true;
        }
        else
        {
            dText.text = dialogueLines[currentLine];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dialogueLines != null && dialogueLines.Length > 0)
        {
            ShowDialogue();
        }
    }
}