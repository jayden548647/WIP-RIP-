using UnityEngine;

public class OtherYou : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Rigidbody2D player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = -player.linearVelocity;
    }
}
