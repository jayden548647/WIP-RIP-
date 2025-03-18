using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
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
        if(collision.gameObject.tag == "EnemyAttack")
        {
            health -= 10;
        }
    }
}