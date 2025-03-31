using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMP_Text finalRoom;
    public TMP_Text finalKill;
    public TMP_Text bitsEarned;
    public TMP_Text bitsTotal;
    public TMP_Text encouragement;
    public float bits;
    public float totalBits;
    public float waitTime = 2;
    public float timer;
    bool canLeave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalRoom.text = "ROOMS CLEAR: " + Manager.instance.GetRoom();
        finalKill.text = "ENEMIES DEFEATED: " + Manager.instance.GetEnemies();

        bits = (Manager.instance.GetRoom() + Manager.instance.GetEnemies()) * 2;
        bits = Mathf.RoundToInt(bits);
        bitsEarned.text = "BITS +" + bits;
        totalBits = Manager.instance.GetBits() + bits;
        bitsTotal.text = "BITS: " + (Manager.instance.GetBits() + bits);
        Manager.instance.SetBits(totalBits);
        timer = 0;
        canLeave = false;
        Manager.instance.SetReviveUnlock(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown && canLeave)
        {
            SceneManager.LoadScene(1);
            Manager.instance.SetRoom(0);
            Manager.instance.SetEnemies(0);
            Manager.instance.SetTempDamageBoost(0);
            Manager.instance.SetTempDefense(0);
        }

        if (Manager.instance.GetRoom() < 100)
        {
            encouragement.color = Color.clear;
        }
        if(Manager.instance.GetRoom() >= 100)
        {
            encouragement.color = Color.white;
        }

        timer += Time.deltaTime;
        if(timer > waitTime)
        {
            canLeave = true;
        }
    }
}
