using UnityEngine;

public class speartree : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public float side;
    public float xpos;
    public float ypos;
    public float survivial;
    public float movespeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        survivial = 7;
        movespeed = 5;
        xpos = -35;
        ypos = Random.Range(-2000, 2000) / 100;
        transform.position = new Vector3(xpos, ypos, -3);
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(1, 0) * movespeed);
        survivial -= Time.deltaTime;
        if(survivial <= 0)
        {
            Destroy(gameObject);
        }
    }
}
