using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    bool endlessUnlocked;
    public TMP_Text endlessText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Screen.fullScreenMode = FullScreenMode.Windowed;
    }
    void Start()
    {
        endlessUnlocked = Manager.instance.GetEndlessUnlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        Manager.instance.LoadGame();
        MusicManager.instance.PlayMusic("LobbyMusic");
        
        SceneManager.LoadScene(1);
        Manager.instance.SetRoom(0);
        Manager.instance.SetEnemies(0);
        Manager.instance.SetTempDefense(0);
        Manager.instance.SetTempDamageBoost(0);
        Manager.instance.SetEndlessActive(false);
        TheChaser.instance.EndRun();
    }

    public void EndlessClick()
    {
    if(endlessUnlocked == false)
        {
            endlessText.text = "lmDF2pq WxCP";
            MusicManager.instance.PlaySFX("Rejection");
        }
    if(endlessUnlocked == true)
        {
            MusicManager.instance.PlayMusic("RunMusic");
            SceneManager.LoadScene(2);
            Manager.instance.SetRoom(0);
            Manager.instance.SetEndlessActive(true);
            TheChaser.instance.EndRun();
        }
    }
    public void BillianClick()
    {
        SceneManager.LoadScene(12);
        MusicManager.instance.PlayMusic("RunMusic");
        Manager.instance.SetRoom(0);
        Manager.instance.SetEndlessActive(true);
        TheChaser.instance.BeginRun();
    }
    public void QuitClick()
    {
        print("quit");
        Application.Quit();
    }

    public void UnpauseClick()
    {
        Time.timeScale = 1f;
    }

    public void MenuClick()
    {
        SceneManager.LoadScene(0);
        MusicManager.instance.PlayMusic("MenuMusic");
        Time.timeScale = 1f;
        TheChaser.instance.EndRun();
    }
    public void HubClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        Manager.instance.SetRoom(0);
        Manager.instance.SetEnemies(0);
        Manager.instance.SetTempDefense(0);
        Manager.instance.SetTempDamageBoost(0);
    }
    public void End()
    {
        Manager.instance.SaveGame();
        Application.Quit();
    }
    public void DeleteClick()
    {
        Manager.instance.ClearSave();
        Application.Quit();
    }
}
