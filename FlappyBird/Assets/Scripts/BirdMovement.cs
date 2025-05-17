using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BirdMovement : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject deathScreen;
    private Rigidbody2D rb2d;

    private void Start()
    {
        deathScreen.SetActive(false);
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb2d.linearVelocity = Vector2.up * jumpSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0f;
            deathScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scoring")
        {
            gameManager.IncreaseScore();
        }
        
    }
}
