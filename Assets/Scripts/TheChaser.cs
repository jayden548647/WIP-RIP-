using UnityEngine;
using UnityEngine.UIElements;

public class TheChaser : MonoBehaviour
{
    public static TheChaser instance;
    [SerializeField] private float speed;
    private GameObject player;
    public Vector2 position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
        Destroy(gameObject);
        }
        
    }
    void Start()
    {
        transform.position = position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        position = transform.position;
        if (player == null)
        {
            Destroy(gameObject);
        }
    }
}
