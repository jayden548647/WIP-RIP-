using UnityEngine;
using UnityEngine.SceneManagement;


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
        position = new Vector2(0, -25);
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        
        if (player == null)
        {
            Destroy(gameObject);
        }

        if(Manager.instance.GetRoom() == 127)
        {
            SceneManager.LoadScene(13);
            EndRun();
            Manager.instance.SetBits(1000000000);
            Manager.instance.SetBillOver(true);
        }
    }
    public void BeginRun()
    {
        transform.position = position;
    }
    public void EndRun()
    {
        Destroy(gameObject);
    }
}
