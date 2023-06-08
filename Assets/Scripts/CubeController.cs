using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CubeController : MonoBehaviour
{
    public GameManager gameManager;
    public float speed = 8f;
    private Vector2 movement;
    private SpriteRenderer _spriteRenderer;
    public Sprite[] sprites;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Meal")
        {
            Destroy(col.gameObject);
            gameManager.score++;
            if (gameManager.score < 10)
            {
                transform.localScale *= 1.05f;
                speed *= 0.97f;
            }
            if (gameManager.score >= 10)
            {
                transform.localScale *= 1.03f;
                speed *= 0.95f;

            }
            if (gameManager.score >= 20)
            {
                transform.localScale *= 1.01f;
                speed *= 0.93f;
            }
        }
    }

    void MoveCube()
    {
        transform.Translate(movement * speed * Time.deltaTime); // Küpü hareket ettir
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // Yatay hareket inputu (Sol, Sağ ok tuşları)
        float moveY = Input.GetAxisRaw("Vertical"); // Dikey hareket inputu (Yukarı, Aşağı ok tuşları)

        movement = new Vector2(moveX, moveY).normalized; // Hareket vektörü

        MoveCube();
    }

}