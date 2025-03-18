using Unity.VisualScripting;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    
    public Transform bulletPos;
    public GameObject Attack;
    public GameObject AttackTarget;
    public float attackTime;
    public float attackCount;
    public float attackChance;
    public bool attacked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AttackTarget = GameObject.FindGameObjectWithTag("Player");
        attackTime = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = AttackTarget.transform.position - transform.position;
        float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, -rotZ);
        attackCount += Time.deltaTime;
        if(attackCount > attackTime)
        {
            attackCount = 0;
            attacked = false;
            attackChance = Random.Range(0, 10);
            
        }
        if(attackChance > 7 && attacked == false)
        {
            attacked = true;
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(Attack, bulletPos.position, Quaternion.identity);
        
    }

    
}
