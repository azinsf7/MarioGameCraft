using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10;
    private float moveInput;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private bool isGrounded;
    private Camera camera;

    public void Init(Camera camera)
    {
        this.camera = camera;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("brick"))
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("brick"))
        {
            isGrounded = true;
        }
    }

    private void Move()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        CheckEdges();

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    private void CheckEdges()
    {
        var pos = rb.transform.position;
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(
            new Vector2(Screen.width, Screen.height));
        pos.x = Mathf.Clamp(transform.position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
        rb.transform.position = pos;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = rb.transform.localScale;
        scale.x *= -1;
        rb.transform.localScale = scale;
    }
}


