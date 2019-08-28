using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GG_moving : MonoBehaviour
{
    public float moveingSpeed = 10f;
    public float jumpForce = 5f;
    public int maxHealth = 5;
    public float timeInvisible = 1.0f;


    private bool faceToRight = true; // нахуя здесь Private?
   
    float horizontalSpeed;
    float invisibleTimer;
    bool isGround = true;
    bool isInvisible = false;
    public int currentHealth { get; private set;}

    Rigidbody2D rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update() // 1 time per frame
    {
        horizontalSpeed = Input.GetAxis("Horizontal"); // where directed speed of GG

        if (isInvisible)
        {
            if (invisibleTimer > 0)
            {
                invisibleTimer -= Time.deltaTime;
            }
            else
            {
                isInvisible = false;
            }
        }

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

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvisible) return;

            isInvisible = true;
            invisibleTimer = timeInvisible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
