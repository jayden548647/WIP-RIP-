using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] float startDashTime = 5f;
    [SerializeField] float dashSpeed = 10f;
    float currentDashTime;
    public float healthMultiplier;
    public float health;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public bool canDash;
    void Start()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        if(healthMultiplier == 0)
        {
            healthMultiplier = 1;
        }
        health = 50 * healthMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {

        if (!Input.GetMouseButton(2) && canDash)
        {
            rb.linearVelocity = movementDirection * movementSpeed;
        }
        if (Input.GetMouseButtonDown(2) && canDash)
        {
            Dash();
        }
    }
    private void Dash()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(Dash(Vector2.up));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(Dash(Vector2.down));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(Dash(Vector2.right));
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(Dash(Vector2.left));
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            StartCoroutine(Dash(Vector2.up + Vector2.left));
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            StartCoroutine(Dash(Vector2.down + Vector2.right));
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            StartCoroutine(Dash(Vector2.right + Vector2.up));
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            StartCoroutine(Dash(Vector2.left + Vector2.down));
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            StartCoroutine(Dash(Vector2.up + Vector2.left));
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            StartCoroutine(Dash(Vector2.down + Vector2.right));
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            StartCoroutine(Dash(Vector2.right + Vector2.up));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            StartCoroutine(Dash(Vector2.left + Vector2.down));
        }
        print("Dash");
    }


    IEnumerator Dash(Vector2 direction)
    {
        canDash = false;
        currentDashTime = startDashTime;
        while(currentDashTime > 0f)
        {
            currentDashTime -= Time.deltaTime;
            rb.linearVelocity = direction * dashSpeed;
            
            yield return null;
        }
        print("Dash2");
        rb.linearVelocity = new Vector2(0f, 0f);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyAttack" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Attack")
        {
            health -= 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 10;
        }
    }
}
