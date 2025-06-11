using UnityEngine;
using UnityEngine.Tilemaps;

public class DialogeHolder : MonoBehaviour
{
    public string dialogue;
    public DialogManager dm;
    private BoxCollider2D bC;

    public GameObject dialogBox;
    public string[] dialogueLines;
    private PlayerMovement playerController;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerMovement>();
        bC = GetComponentInParent<BoxCollider2D>();
        dm = FindObjectOfType<DialogManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //dm.ShowBox(dialogue);
            if (!dm.dialogActive)
            {
                dm.dialogueLines = dialogueLines;
                dm.currentLine = 0;
                dm.ShowDialogue();
                playerController.CanMove = false;
            }
            if (sword.activeInHierarchy)
            {
                dm.dBox.SetActive(false);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dm.dialogActive = false;
        dm.dBox.SetActive(false);
        playerController.CanMove = true;
    }
}
