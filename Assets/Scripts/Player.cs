using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] float startDashTime = 5f;
    [SerializeField] float dashSpeed = 10f;
    float currentDashTime;
    public float healthMultiplier;
    public float defense;
    public float health;
    public float roomsCleared;
    private int rng;
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
        if (defense == 0)
        {
            defense = 1;
        }
        if (Manager.instance.playerHealth == 0)
        {
            health = 50 * healthMultiplier;
        }
        else
        {
            health = Manager.instance.GetHealth();
        }
        roomsCleared = Manager.instance.GetRoom();
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(health <= 0)
        {
            SceneManager.LoadScene(0);
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
        if(collision.gameObject.tag == "EnemyAttack" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Attack" || collision.gameObject.tag == "MovingEnemy")
        {
            health -= 10 / defense;
            Manager.instance.SetHealth(health);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MovingEnemy")
        {
            health -= 10 / defense;

        Manager.instance.SetHealth(health);
        }
        if(collision.gameObject.tag == "Finish")
        {
            roomsCleared++;
            Manager.instance.SetRoom(roomsCleared);
            rng = Random.Range(2, 7);
            SceneManager.LoadScene(rng);
        }
    }
    
}
