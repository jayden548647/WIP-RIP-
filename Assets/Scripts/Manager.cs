using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public float playerHealth;
    public float roomCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(float health)
    {
        playerHealth = health;
    }
    public float GetHealth()
    {
        return playerHealth;
    }
    public void SetRoom(float room)
    {
        roomCount = room;
    }
    public float GetRoom()
    {
        return roomCount;
    }

}
