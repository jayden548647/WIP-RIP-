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
    public float saveTimer;
    public bool unlockRevives;
    public bool unlockEnemy;
    public bool unlockEndless;
    public bool unlockBillian;
    public bool inEndless;
    public bool unlockFix;
    public bool spoken1;
    public bool spoken2;
    public bool cherraDefeated;
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
       LoadGame();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        saveTimer -= Time.deltaTime;
        if(saveTimer <= 0)
        {
            SaveGame();
            saveTimer = 10;
        }
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
        tempBoostValue = tempBoost;
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
    public void SetUSkipUnlock(bool uskipUnlocked)
    {
        unlockFix = uskipUnlocked;
    }
    public bool GetUSkipUnlock()
    {
        return unlockFix;
    }
    public void SetSpeak1(bool speak1)
    {
        spoken1 = speak1;
    }
    public bool GetSpeak1()
    {
        return spoken1; ;
    }
    public void SetSpeak2(bool speak2)
    {
        spoken2 = speak2;
    }
    public bool GetSpeak2()
    {
        return spoken2; ;
    }
    public void SetCherra(bool cherra)
    {
        cherraDefeated = cherra;
    }
    public bool GetCherra()
    {
        return cherraDefeated;
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(this);
    }
    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadGame();
        healthBoost = data.healthMultiplier;
        defenseValue = data.defense;
        boostValue = data.damageBoost;
        rangedValue = data.rangeUpgrade;
        skippedRooms = data.roomSkip;
        reviveCount = data.revives;
        enemyBoost = data.enemyMultiplier;
        bitsCount = data.bits;
        unlockRevives = data.reviveUnlocked;
        unlockEnemy = data.enemyUnlocked;
        unlockEndless = data.endlessUnlocked;
        unlockBillian = data.billianUnlocked;
        unlockFix = data.fixUnlocked;
        spoken1 = data.spoken1;
        spoken2 = data.spoken2;
    }

    public void ClearSave()
    {
        healthBoost = 0;
        defenseValue = 0;
        boostValue = 0;
        rangedValue = 0;
        skippedRooms = 0;
        reviveCount = 0;
        enemyBoost = 0;
        bitsCount = 0;
        unlockRevives = false;
        unlockEnemy = false;
        unlockEndless = false;
        unlockBillian = false;
        unlockFix = false;
        spoken1 = false;
        spoken2 = false;
        
        SaveSystem.SaveGame(this);
    }
}
