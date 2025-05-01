using TMPro;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float health;
    float defeat;
    public float damageBoost;
    float tempDamageBoost;
    float defeatMultiplier;
    public TMP_Text damageBuy;
    public DialogueTrigger cantAfford;
    public DialogueTrigger bought;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Manager.instance.GetDamageBoost() == 0)
        {
            damageBoost = 1 + Manager.instance.GetTempDamageBoost();
            Manager.instance.SetDamageBoost(1);
        }
        if(Manager.instance.GetDamageBoost() > 0)
        {
            damageBoost = Manager.instance.GetDamageBoost() + Manager.instance.GetTempDamageBoost();
            Manager.instance.SetDamageBoost(damageBoost - Manager.instance.GetTempDamageBoost());
        }
        if(Manager.instance.GetEnemyMultiplier() == 0)
        {
            defeatMultiplier = 1;
            Manager.instance.SetEnemyMultipler(1);
        }
        if(Manager.instance.GetEnemyMultiplier() > 0)
        {
            defeatMultiplier = Manager.instance.GetEnemyMultiplier();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            defeat += 1 * (Manager.instance.GetEnemyMultiplier());
            Manager.instance.SetEnemies(defeat);
            Destroy(gameObject);
        }
        defeat = Manager.instance.GetEnemies();
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack" || collision.gameObject.tag == "MeleeAttack")
        {
            health -= 10 * damageBoost;
        }
        if (collision.gameObject.tag == "EnemyAttack")
        {
            health -= 10;
        }
    }


    public void DamageUp()
    {
        if (defeat >= 100)
        {
            defeat -= 100;
            tempDamageBoost = tempDamageBoost + 1;
            damageBuy.text = "PURCHASED";
            Manager.instance.SetTempDamageBoost(tempDamageBoost);
            Manager.instance.SetEnemies(defeat);
            Manager.instance.SetEnemyUnlock(true);
            bought.TriggerDialogue();
        }
        if(defeat < 100)
        {
            cantAfford.TriggerDialogue();
        }
    }
}
