using TMPro;
using UnityEngine;

public class HealthCount : MonoBehaviour
{
    public TMP_Text healthText;
    public TMP_Text roomText;
    public TMP_Text enemyText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + Manager.instance.GetHealth();
        roomText.text = "Rooms Cleared: " + Manager.instance.GetRoom();
        enemyText.text = "Enemies Defeated: " + Manager.instance.GetEnemies();
    }
}
