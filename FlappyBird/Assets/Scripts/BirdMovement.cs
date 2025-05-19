using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject deathScreen;
    [SerializeField] private AudioSource hitSFX;
    [SerializeField] private AudioSource wingSFX;
    [SerializeField] private AudioSource pointSFX;
    [SerializeField] private Vector3 rotationSpeed;
    [SerializeField] private float rotationUpSpeedValue;
    private Rigidbody2D rb2d;
    private bool canJump = true;
    public static bool isBirdAlive = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
        if (IsJumpInputReceived())
        {
            if (canJump)
                Jump();
            if (!deathScreen.gameObject.activeInHierarchy)
            {
                wingSFX.Play();
                transform.rotation = Quaternion.Euler(0, 0, rotationUpSpeedValue);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            isBirdAlive = false;
            hitSFX.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Scoring":
                gameManager.IncreaseScore();
                pointSFX.Play();
                break;
            case "HighLimit":
                canJump = false;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HighLimit")
            canJump = true;
    }

    private void Jump()
    {
        rb2d.linearVelocity = Vector2.up * jumpSpeed;
    }

    bool IsJumpInputReceived()
    {
        bool mousePressed = Input.GetMouseButtonDown(0);

        bool touchPressed = Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began;

        return mousePressed || touchPressed;
    }
}
