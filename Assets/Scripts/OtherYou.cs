using UnityEngine;

public class OtherYou : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Rigidbody2D player;
    public float health;
    public float damageBoost;
    public float bits;
    public DialogueTrigger defeat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 127;
        damageBoost = Manager.instance.GetDamageBoost();
        bits = Manager.instance.GetBits();
    }

    // Update is called once per frame
    void Update()
    {
        if(damageBoost <= 0)
        {
            damageBoost = 1;
        }
        rb.linearVelocity = -player.linearVelocity;
        if(health <= 0)
        {
            bits += 1000000;
            Manager.instance.SetBits(bits);
            defeat.TriggerDialogue();
            gameObject.SetActive(false);
            Manager.instance.SetCherra(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack" || collision.gameObject.tag == "EnemyAttack" || collision.gameObject.tag == "MeleeAttack")
        {
            health = health - (10 * damageBoost);
        }
    }
}
