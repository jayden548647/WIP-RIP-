using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public float playerHealth;
    public float roomCount;
    public float enemiesCount;
    public float defenseValue;
    public float tempDefenseValue;
    public float boostValue;
    public float tempBoostValue;
    public float bitsCount;
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
    public void SetEnemies(float enemies)
    {
        enemiesCount = enemies;
    }
    public float GetEnemies()
    {
        return enemiesCount;
    }

    public void SetDefense(float defense)
    {
        defenseValue = defense;
    }
    public float GetDefense()
    {
        return defenseValue;
    }
    public void SetTempDefense(float tempDefense)
    {
        tempDefenseValue = tempDefense;
    }
    public float GetTempDefense()
    {
        return tempDefenseValue;
    }
    public void SetDamageBoost(float boost)
    {
        boostValue = boost;
    }
    public float GetDamageBoost()
    {
        return boostValue;
    }
    public void SetTempDamageBoost(float tempBoost)
    {
        boostValue = tempBoost;
    }
    public float GetTempDamageBoost()
    {
        return tempBoostValue;
    }
    public void SetBits(float bits)
    {
        bitsCount = bits;
    }
    public float GetBits()
    {
        return bitsCount;
    }
}
