using TMPro;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public float bits;
    public float healthPrice;
    public float defensePrice;
    public float attackPrice;
    public float rangePrice;
    public float skipPrice;
    public float revivePrice;
    public float enemyPrice;
    public float fixPrice;
    public float healthBought;
    public float defenseBought;
    public float attackBought;
    public float rangeBought;
    public float skipBought;
    public float reviveBought;
    public float enemyBought;
    public float healthPriceIncreaseScale;
    public float defensePriceIncreaseScale;
    public float attackPriceIncreaseScale;
    public float rangePriceIncreaseScale;
    public float skipPriceIncreaseScale;
    public float revivePriceIncreaseScale;
    public float enemyPriceIncreaseScale;
    bool reviveUnlocked;
    bool enemyUnlocked;
    bool fixUnlocked;
    string rangeUpgradeType;
    public TMP_Text healthCost;
    public TMP_Text attackCost;
    public TMP_Text rangeCost;
    public TMP_Text defenseCost;
    public TMP_Text skipCost;
    public TMP_Text reviveCost;
    public TMP_Text enemyCost;
    public TMP_Text bitCount;
    public DialogueTrigger cantAfford;
    public DialogueTrigger notUnlocked;
    public DialogueTrigger basicallyNo;
    public DialogueTrigger maxed;
    public DialogueTrigger bought;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bits = Manager.instance.GetBits();
        healthPriceIncreaseScale = 2.5f;
        defensePriceIncreaseScale = 3;
        rangePriceIncreaseScale = 5;
        attackPriceIncreaseScale = 4;
        skipPriceIncreaseScale = 10;
        revivePriceIncreaseScale = 25;
        enemyPriceIncreaseScale = 2;
        enemyUnlocked = Manager.instance.GetEnemyUnlock();
        reviveUnlocked = Manager.instance.GetRevivesUnlock();
        fixUnlocked = Manager.instance.GetUSkipUnlock();
        healthBought = Manager.instance.GetHealthMultiplier() - 1;
        defenseBought = Manager.instance.GetDefense() - 1;
        attackBought = Manager.instance.GetDamageBoost() - 1;
        rangeBought = Manager.instance.GetRangeUpgrade();
        skipBought = Manager.instance.GetRoomSkip();
        reviveBought = Manager.instance.GetRevives();
        enemyBought = Manager.instance.GetEnemyMultiplier() - 1;

        if(healthBought < 0)
        {
            healthBought = 0;
        }
        if(defenseBought < 0)
        {
            defenseBought = 0;
        }
        if(attackBought < 0)
        {
            attackBought = 0;
        }
        if(enemyBought < 0)
        {
            enemyBought = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(rangeBought == 0)
        {
            rangeUpgradeType = "Throw ";
        }
        if(rangeBought == 1)
        {
            rangeUpgradeType = "Piercing ";
        }
        if(rangeBought == 2)
        {
            rangeUpgradeType = "No Clip Stick ";
        }
        if (rangeBought == 3)
        {
            rangeUpgradeType = "Duplication ";
        }
        if(rangeBought == 4)
        {
            rangeUpgradeType = "No More ";
        }
        healthPrice = 40 * (healthPriceIncreaseScale * (healthBought + 1));
        defensePrice = 50 * (defensePriceIncreaseScale * (defenseBought + 1));
        attackPrice = 100 * (attackPriceIncreaseScale * (attackBought + 1));
        rangePrice = 40 * (rangePriceIncreaseScale * (rangeBought + 1));
        skipPrice = 75 * (skipPriceIncreaseScale * (skipBought + 1));
        revivePrice = 200 * (revivePriceIncreaseScale * (reviveBought + 1));
        enemyPrice = 200 * enemyPriceIncreaseScale * (enemyBought + 1);
        healthCost.text = "Health UP " + healthPrice + " Bits";
        defenseCost.text = "Resist UP " + defensePrice + " Bits";
        attackCost.text = "Damage UP " + attackPrice + " Bits";
        rangeCost.text = rangeUpgradeType + rangePrice + " Bits";
        skipCost.text = "Late Start " + skipPrice + " Bits";
        reviveCost.text = "REVIVE " + revivePrice + " Bits";
        enemyCost.text = "Enemy Multiplier " + enemyPrice + " Bits";
        bitCount.text = "" + bits;
        if(bits < 0)
        {
            bits = 0;
            Manager.instance.SetBits(bits);
        }
    }

    public void HealthBuy()
    {
        if (Manager.instance.GetBits() >= 40 * (healthPriceIncreaseScale * (healthBought + 1)) && healthBought < 5)
        {
            bits -= 40 * (healthPriceIncreaseScale * (healthBought + 1));
            healthBought += 1;
            Manager.instance.SetHealthMultiplier(healthBought + 1);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }

        if (Manager.instance.GetBits() < 40 * (healthPriceIncreaseScale * (healthBought + 1)) && healthBought < 5)
        {
            cantAfford.TriggerDialogue();
        }
        if(healthBought >= 5)
        {
            maxed.TriggerDialogue();
        }
    }
    public void DefenseBuy()
    {
        if (Manager.instance.GetBits() >= 50 * (defensePriceIncreaseScale * (defenseBought + 1)) && defenseBought < 3)
        {
            bits -= 50 * (defensePriceIncreaseScale * (defenseBought + 1));
            defenseBought += 1;
            Manager.instance.SetDefense(defenseBought + 1);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 50 *  (defensePriceIncreaseScale * (defenseBought + 1)) && defenseBought < 3)
        {
            cantAfford.TriggerDialogue();
        }
        if(defenseBought >= 3)
        {
            maxed.TriggerDialogue();
        }
    }
    public void AttackBuy()
    {
        if (Manager.instance.GetBits() >= 100 * (attackPriceIncreaseScale * (attackBought + 1)) && attackBought < 3)
        {
            bits -= 100 * (attackPriceIncreaseScale * (attackBought + 1));
            attackBought += 1;
            Manager.instance.SetDamageBoost(attackBought + 1);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 100 * (attackPriceIncreaseScale * (attackBought + 1)) && attackBought < 3)
        {
            cantAfford.TriggerDialogue();
        }
        if(attackBought >= 3)
        {
            maxed.TriggerDialogue();
        }
    }
    public void RangeBuy()
    {
        if (Manager.instance.GetBits() >= 40 * (rangePriceIncreaseScale * (rangeBought + 1)) && rangeBought < 4)
        {
            bits -= 40 * (rangePriceIncreaseScale * (rangeBought + 1));
            rangeBought += 1;
            Manager.instance.SetRangeUpgrade(rangeBought);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 40 * (rangePriceIncreaseScale * (rangeBought + 1)) && rangeBought < 4)
        {
            cantAfford.TriggerDialogue();
        }
        if(rangeBought >= 4)
        {
            maxed.TriggerDialogue();
        }
    }

    public void SkipBuy()
    {
        if(Manager.instance.GetBits() >= 75 * (skipPriceIncreaseScale * (skipBought + 1)) && skipBought < 5)
        {
            bits -= 75 * (skipPriceIncreaseScale * (skipBought + 1));
            skipBought += 1;
            Manager.instance.SetRoomSkip(skipBought);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 75 * (skipPriceIncreaseScale * (skipBought + 1)) && skipBought < 5)
        {
            cantAfford.TriggerDialogue();
        }
        if(skipBought >= 5)
        {
            maxed.TriggerDialogue();
        }
    }
    public void ReviveBuy()
    {
        if(Manager.instance.GetBits() >= 200 * (revivePriceIncreaseScale * (reviveBought + 1)) && reviveBought < 2 && reviveUnlocked)
        {
            bits -= 200 * (revivePriceIncreaseScale * (reviveBought + 1));
            reviveBought += 1;
            Manager.instance.SetRevives(reviveBought);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if (Manager.instance.GetBits() < 200 * (revivePriceIncreaseScale * (reviveBought + 1)) && reviveBought < 2 && reviveUnlocked)
        {
            cantAfford.TriggerDialogue();
        }
        if(Manager.instance.GetBits() >= 200 * (revivePriceIncreaseScale * (reviveBought + 1)) && !reviveUnlocked)
        {
            notUnlocked.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 200 * (revivePriceIncreaseScale * (reviveBought + 1)) && !reviveUnlocked)
        {
            basicallyNo.TriggerDialogue();
        }
        if(reviveBought >= 2)
        {
            maxed.TriggerDialogue();
        }
    }
    public void EnemyBuy()
    {
        if(Manager.instance.GetBits() >= 200 * (enemyPriceIncreaseScale * (enemyBought + 1)) && enemyBought < 2 && enemyUnlocked)
        {
            bits -= 200 * (enemyPriceIncreaseScale * (enemyBought + 1));
            enemyBought += 1;
            Manager.instance.SetEnemyMultipler(enemyBought + 1);
            Manager.instance.SetBits(bits);
            MusicManager.instance.PlaySFX("Purchase");
            bought.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 200 * (enemyPriceIncreaseScale * (enemyBought + 1)) && enemyBought < 2 && enemyUnlocked)
        {
            cantAfford.TriggerDialogue();
        }
        if(Manager.instance.GetBits() >= 200 * (enemyPriceIncreaseScale * (enemyBought + 1)) && !enemyUnlocked)
        {
            notUnlocked.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 200 * (enemyPriceIncreaseScale *  (enemyBought + 1)) && !enemyUnlocked)
        {
            basicallyNo.TriggerDialogue();
        }
        if(enemyBought >= 2)
        {
            maxed.TriggerDialogue();
        }
    }
    public void FixBuy()
    {
        if(Manager.instance.GetBits() >= 1000000 && fixUnlocked)
        {
            Debug.Log("To da boss");
            Manager.instance.SetRoom(127);
        }
        if(Manager.instance.GetBits() < 1000000 && fixUnlocked)
        {
            cantAfford.TriggerDialogue();
        }
        if(!fixUnlocked && Manager.instance.GetBits() >= 1000000)
        {
            notUnlocked.TriggerDialogue();
        }
        if(Manager.instance.GetBits() < 1000000 && !fixUnlocked)
        {
            basicallyNo.TriggerDialogue();
        }
    }
}
