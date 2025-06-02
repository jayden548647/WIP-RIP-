using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float bits;
    public float healthMultiplier;
    public float defense;
    public float damageBoost;
    public float revives;
    public float enemyMultiplier;
    public float roomSkip;
    public float rangeUpgrade;
    public float highScore;
    public bool spoken1;
    public bool spoken2;
    public bool reviveUnlocked;
    public bool enemyUnlocked;
    public bool fixUnlocked;
    public bool endlessUnlocked;
    public bool billianUnlocked;
    public bool billianBeaten;
    public bool oldSave;

    public PlayerData (Manager manager)
    {
        bits = manager.bitsCount;
        healthMultiplier = manager.healthBoost;
        defense = manager.defenseValue;
        damageBoost = manager.boostValue;
        revives = manager.reviveCount;
        enemyMultiplier = manager.enemyBoost;
        roomSkip = manager.skippedRooms;
        rangeUpgrade = manager.rangedValue;
        spoken1 = manager.spoken1;
        spoken2 = manager.spoken2;
        reviveUnlocked = manager.unlockRevives;
        enemyUnlocked = manager.unlockEnemy;
        fixUnlocked = manager.unlockFix;
        endlessUnlocked = manager.unlockEndless;
        billianUnlocked = manager.unlockBillian;
        highScore = manager.highScore;
        billianBeaten = manager.billianBeaten;
        oldSave = manager.oldSave;
    }
}
