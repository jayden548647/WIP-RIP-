using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadTime : MonoBehaviour
{
    public float wait;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wait = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.instance.GetCherra() == true)
        {
            wait -= Time.deltaTime;
        }
        if(wait <= 0)
        {
            SceneManager.LoadScene(8);
            MusicManager.instance.PlayMusic("WaitForTheWorld");
            Manager.instance.SetCherra(false);
        }
    }
}
