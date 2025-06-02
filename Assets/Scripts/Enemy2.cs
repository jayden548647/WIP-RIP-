using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    public float health;
    float defeat;
    public float damageBoost;
    public SpriteRenderer sr;
    public float damageShift;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
        if (Manager.instance.GetDamageBoost() == 0)
        {
            damageBoost = 1 + Manager.instance.GetTempDamageBoost();
            Manager.instance.SetDamageBoost(1);
        }
        else
        {
            damageBoost = Manager.instance.GetDamageBoost() + Manager.instance.GetTempDamageBoost();
            Manager.instance.SetDamageBoost(damageBoost - Manager.instance.GetTempDamageBoost());
        }
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        defeat = Manager.instance.GetEnemies();
        if(damageShift > 0)
        {
            damageShift -= Time.deltaTime;
            sr.color = Color.grey;

        }
        if(damageShift <= 0)
        {
            sr.color = Color.white;
        }
        
        if (health <= 0)
        {
            defeat += 1 * (Manager.instance.GetEnemyMultiplier());
            Manager.instance.SetEnemies(defeat);
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            health -= 10 * damageBoost;
            damageShift = 0.2f;
        }
        if(collision.gameObject.tag == "MeleeAttack")
        {
            health -= 10 * damageBoost;
            damageShift = 0.2f;
        }
    }
}