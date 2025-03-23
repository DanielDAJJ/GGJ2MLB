using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private AnimationManager animationManager;
    [SerializeField]private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animationManager = GetComponentInChildren<AnimationManager>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Limit"))
        {
            rb.velocity = Vector2.zero;
        }
        if (other.gameObject.CompareTag("bird") || other.gameObject.CompareTag("tree") || other.gameObject.CompareTag("cloud"))
        {
            isDead = true;
            animationManager.SetOnCollision(true);
            Debug.Log("Game Over");
            GameManager.Instance.GameOver();
        }
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0);
        if (isDead) return;
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
        if (rb.velocity.y > 0) return;
    }
}
