using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float xpos;
    public float ypos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        xpos = Random.Range(-3000, 3000);
        ypos = Random.Range(-2000, 2000);
        xpos /= 100;
        ypos /= 100;
        transform.position = new Vector3(xpos, ypos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExplosionEnd()
    {
        Destroy(gameObject);
    }
    public void BitBoom()
    {
        gameObject.tag = "BossAttack";
    }
}
