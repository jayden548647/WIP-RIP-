using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class IAmTheBoss : MonoBehaviour
{
    public Rigidbody2D rb;
    public float switchsides;
    public float movechange;
    public float attack;
    public float attackWait;
    public float health;
    public float immunity;
    public float speed = 1.25f;
    public int boom;
    public GameObject bit;
    public GameObject virus;
    public GameObject tree;
    public GameObject minion;
    public Vector2 minionXpos;
    public Vector2 minionYpos;
    public Transform rightposition;
    public Transform leftposition;
    public DialogueTrigger dontGetDistracted;
    public TMP_Text healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 127;
        healthText.text = "Boss Health: " + health + "/127";
        speed = 6;
        
        switchsides = Random.Range(500, 2000) / 100;
        attackWait = Random.Range(100, 300) / 100;
        movechange = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            if(attack == 3)
            {
                MassInfection();
                attack = 0;
            }
            if (attack == 4)
            {
                PointingForests();
                attack = 0;
            }
            
            attackWait = Random.Range(0, 200) / 100;
        }
        if(immunity > 0)
        {
            immunity -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        movechange -= Time.deltaTime;
        if (movechange < 0)
        {
            Vector2 Movement = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
            rb.AddForce(Movement * speed);
            movechange = Random.Range(2, 3);
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
    public void MassInfection()
    {
        Instantiate(virus);
    }
    public void PointingForests()
    {
        Instantiate(tree);
    }
    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "EnemyAttack")
        {
            if (immunity <= 0)
            {
                health -= 1.27f;
                immunity = 2;
                healthText.text = "Boss Health: " + health + "/127";
            }
        }
    }
}
