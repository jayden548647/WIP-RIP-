using UnityEngine;
using UnityEngine.Rendering;

public class IAmTheBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public float switchsides;
    public float movechange;
    public float attack;
    public float attackWait;
    public float health;
    public float speed = 1.25f;
    public int boom;
    public GameObject bit;
    public Vector2 leftpos;
    public Vector2 rightpos;
    public Transform rightposition;
    public Transform leftposition;
    public DialogueTrigger dontGetDistracted;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 127;
        speed = 2;
        leftpos = leftposition.position;
        rightpos = rightposition.position;
        switchsides = Random.Range(500, 2000) / 100;
        attackWait = Random.Range(100, 300) / 100;
        movechange = 2;
    }

    // Update is called once per frame
    void Update()
    {
        switchsides -= Time.deltaTime;
        if(switchsides < 0)
        {
            switchsides = Random.Range(500, 2000) / 100;
            if (transform.position.x < -0.1)
            {
                SideRight();
            }
            if(transform.position.x > 0.1)
            {
                SideLeft();
            }
           
            
        }
        if(boom > 0)
        {
            Instantiate(bit);
            boom--;
        }
        attackWait -= Time.deltaTime;
        if (attackWait < 0)
        {
            attack = Random.Range(1, 5);
            if(attack == 1)
            {
                BitBoom();
                attack = 0;
            }
            if (attack == 2)
            {
                DialogueDistraction();
                attack = 0;
            }
            attackWait = Random.Range(100, 200) / 100;
        }
    }
    private void FixedUpdate()
    {
        movechange -= Time.deltaTime;
        if (movechange < 0)
        {
            Vector2 Movement = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            rb.AddForce(Movement * speed);
            movechange = Random.Range(1, 2);
        }
    }
    public void BitBoom()
    {
        boom = 30;
    }
    public void DialogueDistraction()
    {
        dontGetDistracted.TriggerDialogue();
    }
    public void SideRight()
    {
        transform.position = rightpos;
    }
    public void SideLeft()
    {
        transform.position = leftpos;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack" || collision.gameObject.tag == "EnemyAttack")
        {
            health -= 1;
        }
    }
}
