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
    public float revives;
    private int rng;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private Vector3 startPos;
    public bool canDash;
    public GameObject upgradeMenu;
    public GameObject shopMenu;
    public TMP_Text healthBuy;
    public TMP_Text defenseBuy;
    public DialogueTrigger cantAfford;
    public DialogueTrigger dontNeed;
    public bool spokenToCam;
    public bool spokenToCam2;
    public DialogueTrigger overHere;
    public DialogueTrigger introduction;
    
    void Start()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        spokenToCam = Manager.instance.GetSpeak1();
        spokenToCam2 = Manager.instance.GetSpeak2();
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
            if (revives <= 0)
            {
                SceneManager.LoadScene(4);
            }
            else
            {
                revives--;
                Manager.instance.SetRevives(revives);
                Revive();
            }
        }
        enemyDefeats = Manager.instance.GetEnemies();
        revives = Manager.instance.GetRevives();

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
            if(spokenToCam2 == false)
            {
                introduction.TriggerDialogue();
                spokenToCam2 = true;
                Manager.instance.SetSpeak2(true);
            }
            if (spokenToCam2 == true)
            {
                upgradeMenu.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "ShopOpen")
        {
            shopMenu.gameObject.SetActive(true);
        }
        if(collision.gameObject.tag == "HealthSet")
        {
            health = 50 * healthMultiplier;
            Manager.instance.SetHealth(health);
            if(spokenToCam2 == false)
            {
                introduction.TriggerDialogue();
                Manager.instance.SetSpeak2(true);
            }
        }
        if (collision.gameObject.tag == "Spawn")
        {
            if(spokenToCam == false)
            {
                overHere.TriggerDialogue();
                spokenToCam = true;
                Manager.instance.SetSpeak1(true);
            }
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
                rng = Random.Range(5, 11);
                SceneManager.LoadScene(rng);
            }
        }
        if(collision.gameObject.tag == "Enter")
        {
            SceneManager.LoadScene(2);
            Manager.instance.SetRoom(0 + (5 * Manager.instance.GetRoomSkip()));
            health = 50 * healthMultiplier;
        }
        
    }
    
    public void FullHeal()
    {
        if (enemyDefeats >= 10 && health < (50 * healthMultiplier))
        {
            enemyDefeats -= 10;
            health = 50 * healthMultiplier;
            healthBuy.text = "PURCHASED";
            Manager.instance.SetHealth(health);
            Manager.instance.SetEnemies(enemyDefeats);
            Manager.instance.SetEnemyUnlock(true);
        }
        if(enemyDefeats < 10 && health < (50 * healthMultiplier))
        {
            cantAfford.TriggerDialogue();
        }
        if(health >= (50 * healthMultiplier))
        {
            dontNeed.TriggerDialogue();
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
            Manager.instance.SetEnemyUnlock(true);
        }
        if(enemyDefeats < 40)
        {
            cantAfford.TriggerDialogue();
        }
        
    }
    public void Revive()
    {
        health = 50 * healthMultiplier;
        transform.position = startPos;
    }
}
