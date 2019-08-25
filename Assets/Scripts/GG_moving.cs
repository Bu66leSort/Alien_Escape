using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG_moving : MonoBehaviour
{
    public float moveingSpeed = 10f;
    public float jumpForce = 5f;

    private bool faceToRight = true;
    float horizontalSpeed;
    bool isGround = true;

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() // 1 time per frame
    {
        horizontalSpeed = Input.GetAxis("Horizontal"); // where directed speed of GG

        Jump();
    }

    void FixedUpdate() // 50 times per second (can be changed)
    {
        Moveing();
        FaceDirected();
    }

    void Moveing() // Moveing gg to left or to right
    {
        Vector2 position = new Vector2(transform.position.x + moveingSpeed * horizontalSpeed * Time.deltaTime, transform.position.y);
        rigidBody.transform.position = position;
    }

    void FaceDirected()
    {
        if (faceToRight && horizontalSpeed < 0)
        {
            faceToRight = !faceToRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (!faceToRight && horizontalSpeed > 0)
        {
            faceToRight = !faceToRight;
            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    void Jump()
    {
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGround = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
}
