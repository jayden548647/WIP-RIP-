using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class bulletScript : MonoBehaviour
{
    private float timer;
    public float timeToExist;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > timeToExist)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            if (Manager.instance.GetRangeUpgrade() <= 2)
            {
                Destroy(gameObject);
            }

        }
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MovingEnemy" || collision.gameObject.tag == "Player")
        {
            if (Manager.instance.GetRangeUpgrade() == 1)
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "Cam" || collision.gameObject.tag == "MeleeAttack")
        {
            rb.linearVelocity = -rb.linearVelocity;
        }
    }
}
