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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        Manager.instance.LoadGame();
        SceneManager.LoadScene(1);
        Manager.instance.SetRoom(0);
        Manager.instance.SetEnemies(0);
        Manager.instance.SetTempDefense(0);
        Manager.instance.SetTempDamageBoost(0);
    }

    public void EndlessClick()
    {
    if(endlessUnlocked == false)
        {
            endlessText.text = "lmDF2pq WxCP";
        }
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
        Time.timeScale = 1f;
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
    public void DeleteClick()
    {
        SaveSystem.ClearSave();
    }
}
