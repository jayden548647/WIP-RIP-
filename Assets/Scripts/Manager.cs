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
    public float healthBoost;
    public float rangedValue;
    public float skippedRooms;
    public float reviveCount;
    public float enemyBoost;
    public bool unlockRevives;
    public bool unlockEnemy;
    public bool unlockEndless;
    public bool unlockBillian;
    public bool inEndless;
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
    public void SetHealthMultiplier(float healthUp)
    {
        healthBoost = healthUp;
    }
    public float GetHealthMultiplier()
    {
        return healthBoost;
    }

    public void SetRangeUpgrade(float rangeUpgrade)
    {
        rangedValue = rangeUpgrade;
    }
    public float GetRangeUpgrade()
    {
        return rangedValue;
    }
    public void SetRoomSkip(float roomSkip)
    {
        skippedRooms = roomSkip;
    }
    public float GetRoomSkip()
    {
        return skippedRooms;
    }
    public void SetRevives(float revives)
    {
        reviveCount = revives;
    }
    public float GetRevives()
    {
        return reviveCount;
    }
    public void SetEnemyMultipler(float enemyMultipler)
    {
        enemyBoost = enemyMultipler;
    }
    public float GetEnemyMultiplier()
    {
        return enemyBoost;
    }

    public void SetReviveUnlock(bool reviveUnlocked)
    {
        unlockRevives = reviveUnlocked;
    }
    public bool GetRevivesUnlock()
    {
        return unlockRevives;
    }
    public void SetEnemyUnlock(bool enemyUnlocked)
    {
        unlockEnemy = enemyUnlocked;
    }
    public bool GetEnemyUnlock()
    {
        return unlockEnemy;
    }
    public void SetEndlessUnlock(bool endlessUnlocked)
    {
        unlockEndless = endlessUnlocked;
    }
    public bool GetEndlessUnlock()
    {
        return unlockEndless;
    }
    public void SetUnlockBillian(bool billianUnlock)
    {
        unlockBillian = billianUnlock;
    }
    public bool GetUnlockBillian()
    {
        return unlockBillian;
    }
    public void SetEndlessActive(bool endless)
    {
        inEndless = endless;
    }
    public bool GetEndlessActive()
    {
        return inEndless;
    }
}
