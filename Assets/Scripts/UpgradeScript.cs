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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bits = Manager.instance.GetBits();
        healthPriceIncreaseScale = 2.5f;
        defensePriceIncreaseScale = 3;
        rangePriceIncreaseScale = 5;
        attackPriceIncreaseScale = 4;
        rangePriceIncreaseScale = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
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
            bits -= 40 * (defensePriceIncreaseScale * (defenseBought + 1));
            healthBought += 1;
            Manager.instance.SetDefense(defenseBought + 1);
            Manager.instance.SetBits(bits);
        }
    }
    public void AttackBuy()
    {
        if (Manager.instance.GetBits() >= 100 * (attackPriceIncreaseScale * (attackBought + 1)) && attackBought < 3)
        {
            bits -= 40 * (attackPriceIncreaseScale * (attackBought + 1));
            healthBought += 1;
            Manager.instance.SetDamageBoost(attackBought + 1);
            Manager.instance.SetBits(bits);
        }
    }
    public void RangeBuy()
    {
        if (Manager.instance.GetBits() >= 40 * (rangePriceIncreaseScale * (healthBought + 1)) && healthBought < 5)
        {
            bits -= 40 * (healthPriceIncreaseScale * (healthBought + 1));
            healthBought += 1;
            Manager.instance.SetHealthMultiplier(healthBought + 1);
            Manager.instance.SetBits(bits);
        }
    }

}
