using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BallControllerVertical : MonoBehaviour
{
    public float horizontalForce = 5f;
    public float speed = -1f;
    private Rigidbody2D rb;
    private bool isDead = false;
    private CameraController cameraController;
    public AudioClip jumpSound;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cameraController = Camera.main.GetComponent<CameraController>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.GetCheckpoint();
            if (cameraController != null)
            {
                cameraController.UpdateOffset();
            }
        }
    }

    void Update()
    {
        if (!isDead)
        {
            VerticalMove();
            CheckMovementInput();
        }
    }

    void VerticalMove()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, speed);
    }

    void CheckMovementInput()
    {
        if (isMovingLeft)
        {
            rb.AddForce(Vector2.left * horizontalForce, ForceMode2D.Force);
        }
        else if (isMovingRight)
        {
            rb.AddForce(Vector2.right * horizontalForce, ForceMode2D.Force);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * horizontalForce, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * horizontalForce, ForceMode2D.Force);
        }
    }

    void Die()
    {
        isDead = true;
        rb.linearVelocity = Vector2.zero;
        rb.simulated = false;
        Invoke("Respawn", 2f);
        audioSource.PlayOneShot(deathSound);
    }

    void Respawn()
    {
        if (GameManager.instance != null)
        {
            transform.position = GameManager.instance.GetCheckpoint();
            rb.linearVelocity = Vector2.zero;
            rb.simulated = true;
            isDead = false;
            if (cameraController != null)
            {
                cameraController.UpdateOffset();
                cameraController.ForceUpdatePosition();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            speed = speed * 1.2f;
        }
        if (other.CompareTag("RestartLevel") || other.CompareTag("Obstacle"))
        {
            StartCoroutine(ChangeColorTemporarily(Color.red));
            Die();
        }
        if (other.CompareTag("SpeedUpper"))
        {
            speed = speed * 1.2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("SpeedCutter"))
        {
            speed = speed * 0.7f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("JumpUpper"))
        {
            horizontalForce = horizontalForce * 1.2f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("JumpCutter"))
        {
            horizontalForce = horizontalForce * 0.5f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FullUpper"))
        {
            horizontalForce = horizontalForce * 1.5f;
            speed = speed * 1.5f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("FullCutter"))
        {
            horizontalForce = horizontalForce * 0.5f;
            speed = speed * 0.7f;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("EndLevel"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.ResetCheckPoint();
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void PlayJumpSound()
    {
        if (audioSource != null && jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound);
        }
    }

    IEnumerator ChangeColorTemporarily(Color newColor)
    {
        spriteRenderer.color = newColor;
        yield return new WaitForSeconds(2f);
        spriteRenderer.color = originalColor;
    }
}
