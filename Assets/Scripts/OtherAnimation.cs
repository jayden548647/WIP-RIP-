using UnityEngine;

public class OtherAnimation : MonoBehaviour
{
    public Animator cherra;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.linearVelocity.x == 0 && rb.linearVelocity.y == 0)
        {
            cherra.SetBool("moving", false);
        }
        if(rb.linearVelocity.x < 0)
        {
            cherra.SetBool("moving", true);
            cherra.SetBool("facingsideways", true);
            sr.flipX = true;
        }
        if(rb.linearVelocity.x > 0)
        {
            cherra.SetBool("moving", true);
            cherra.SetBool("facingsideways", true);
            sr.flipX = false;
        }
        if(rb.linearVelocity.y < 0 && rb.linearVelocity.x == 0)
        {
            cherra.SetBool("moving", true);
            cherra.SetBool("facingsideways", false);
            cherra.SetBool("facingaway", false);
            sr.flipX= false;
        }
        if(rb.linearVelocity.y > 0 && rb.linearVelocity.x == 0)
        {
            cherra.SetBool("moving", true);
            cherra.SetBool("facingsideways", false);
            cherra.SetBool("facingaway", true);
            sr.flipX = false;
        }
    }
}
