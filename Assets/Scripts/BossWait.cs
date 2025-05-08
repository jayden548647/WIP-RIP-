using UnityEngine;
using UnityEngine.SceneManagement;

public class BossWait : MonoBehaviour
{
    public float countdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown < 0)
        {
            SceneManager.LoadScene(9);
            Manager.instance.SetRoom(127);
            MusicManager.instance.PlayMusic("BuggedBattle");
            Manager.instance.SetTempDamageBoost(0);
            Manager.instance.SetRevives(0);
        }
    }
}
