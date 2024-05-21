using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float movSpeed;
    public static float speedX, speedY;
    public static Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        movSpeed = 25;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movSpeed = 10;
            speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
            speedY = Input.GetAxisRaw("Vertical") * movSpeed;
            rb.velocity = new Vector2(speedX, speedY);
        }
        else
        {
            movSpeed = 5;
            speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
            speedY = Input.GetAxisRaw("Vertical") * movSpeed;
            rb.velocity = new Vector2(speedX, speedY);
        }

    }
}
