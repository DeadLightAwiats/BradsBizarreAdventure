using UnityEngine;

public class EndlessMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirection = Input.GetAxisRaw("Vertical");
        rb.velocity =new Vector2(0, moveDirection * moveSpeed);
    }
}
