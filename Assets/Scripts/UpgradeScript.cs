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
    public float healthBought;
    public float defenseBought;
    public float attackBought;
    public float rangeBought;
    public float skipBought;
    public float healthPriceIncreaseScale;
    public float defensePriceIncreaseScale;
    public float attackPriceIncreaseScale;
    public float rangePriceIncreaseScale;
    public float skipPriceIncreaseScale;
    string rangeUpgradeType;
    public TMP_Text healthCost;
    public TMP_Text attackCost;
    public TMP_Text rangeCost;
    public TMP_Text defenseCost;
    public TMP_Text skipCost;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bits = Manager.instance.GetBits();
        healthPriceIncreaseScale = 2.5f;
        defensePriceIncreaseScale = 3;
        rangePriceIncreaseScale = 5;
        attackPriceIncreaseScale = 4;
        skipPriceIncreaseScale = 10;
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
            rangeUpgradeType = "Ghost Stick ";
        }
        if (rangeBought == 3)
        {
            rangeUpgradeType = "No More ";
        }
        healthPrice = 40 * (healthPriceIncreaseScale * (healthBought + 1));
        defensePrice = 50 * (defensePriceIncreaseScale * (defenseBought + 1));
        attackPrice = 100 * (attackPriceIncreaseScale * (attackBought + 1));
        rangePrice = 40 * (rangePriceIncreaseScale * (rangeBought + 1));
        skipPrice = 75 * (skipPriceIncreaseScale * (skipBought + 1));
        healthCost.text = "Health UP " + healthPrice + " Bits";
        defenseCost.text = "Resist UP " + defensePrice + " Bits";
        attackCost.text = "Damage UP " + attackPrice + " Bits";
        rangeCost.text = rangeUpgradeType + rangePrice + " Bits";
        skipCost.text = "Late Start " + skipPrice + " Bits";

    }

    public void HealthBuy()
    {
        if(Manager.instance.GetBits() >= 40 * (healthPriceIncreaseScale * (healthBought + 1)) && healthBought < 5)
        {
            bits -= 40 * (healthPriceIncreaseScale * (healthBought + 1));
            healthBought += 1;
            Manager.instance.SetHealthMultiplier(healthBought + 1);
            Manager.instance.SetBits(bits);
        }
    }
    public void DefenseBuy()
    {
        if (Manager.instance.GetBits() >= 50 * (defensePriceIncreaseScale * (defenseBought + 1)) && defenseBought < 3)
        {
            bits -= 50 * (defensePriceIncreaseScale * (defenseBought + 1));
            healthBought += 1;
            Manager.instance.SetDefense(defenseBought + 1);
            Manager.instance.SetBits(bits);
        }
    }
    public void AttackBuy()
    {
        if (Manager.instance.GetBits() >= 100 * (attackPriceIncreaseScale * (attackBought + 1)) && attackBought < 3)
        {
            bits -= 100 * (attackPriceIncreaseScale * (attackBought + 1));
            healthBought += 1;
            Manager.instance.SetDamageBoost(attackBought + 1);
            Manager.instance.SetBits(bits);
        }
    }
    public void RangeBuy()
    {
        if (Manager.instance.GetBits() >= 40 * (rangePriceIncreaseScale * (rangeBought + 1)) && rangeBought < 3)
        {
            bits -= 40 * (rangePriceIncreaseScale * (rangeBought + 1));
            rangeBought += 1;
            Manager.instance.SetRangeUpgrade(rangeBought);
            Manager.instance.SetBits(bits);
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
        }
    }

}
