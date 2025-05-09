using UnityEngine;
using UnityEngine.SceneManagement;

public class CherraHelp : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D player;
    public float health;
    public float defense;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = Manager.instance.GetHealth();
        defense = Manager.instance.GetDefense();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = -player.linearVelocity;
        if(health <= 0)
        {
            SceneManager.LoadScene(9);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack" || collision.gameObject.tag == "BossAttack")
        {
            health -= (10/defense);
            Manager.instance.SetHealth(health);
            MusicManager.instance.PlaySFX("Hit");
        }
    }
}
