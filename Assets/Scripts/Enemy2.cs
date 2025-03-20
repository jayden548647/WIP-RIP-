using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            health -= 10;
        }
        if(collision.gameObject.tag == "MeleeAttack")
        {
            health -= 10;
        }
    }
}