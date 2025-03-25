using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
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
    public float tempDefense;
    public float health;
    public float roomsCleared;
    public float enemyDefeats;
    private int rng;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    public bool canDash;
    public GameObject upgradeMenu;
    public GameObject shopMenu;
    public TMP_Text healthBuy;
    public TMP_Text defenseBuy;
    
    void Start()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        if(Manager.instance.GetHealthMultiplier() == 0)
        {
            healthMultiplier = 1;
        }
        if(Manager.instance.GetHealthMultiplier() != 0)
        {
            healthMultiplier = Manager.instance.GetHealthMultiplier();
        }
        if (Manager.instance.GetDefense() == 0)
        {
            defense = 1 + Manager.instance.GetTempDefense();
        }
        if(Manager.instance.GetDefense() > 0)
        {
            defense = Manager.instance.GetDefense() + Manager.instance.GetTempDefense();
        }
        if (Manager.instance.playerHealth == 0)
        {
            health = 50 * healthMultiplier;
            Manager.instance.SetHealth(health);
        }
        if (Manager.instance.playerHealth > 0)
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
            SceneManager.LoadScene(4);
        }
        enemyDefeats = Manager.instance.GetEnemies();
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
        if(collision.gameObject.tag == "UpgradeOpen")
        {
            upgradeMenu.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "ShopOpen")
        {
            shopMenu.gameObject.SetActive(true);
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
            if (roomsCleared == 50)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                rng = Random.Range(5, 10);
                SceneManager.LoadScene(rng);
            }
        }
        if(collision.gameObject.tag == "Enter")
        {
            SceneManager.LoadScene(2);
        }
        
    }
    
    public void FullHeal()
    {
        if (enemyDefeats >= 10)
        {
            enemyDefeats -= 10;
            health = 50 * healthMultiplier;
            healthBuy.text = "PURCHASED";
            Manager.instance.SetHealth(health);
            Manager.instance.SetEnemies(enemyDefeats);
        }
    }

    public void DefenseUp()
    {
        if(enemyDefeats >= 40)
        {
            enemyDefeats -= 40;
            tempDefense = tempDefense + 1;
            defenseBuy.text = "PURCHASED";
            Manager.instance.SetTempDefense(tempDefense);
            Manager.instance.SetEnemies(enemyDefeats);
        }
        
    }
}
