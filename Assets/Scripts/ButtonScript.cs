using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    bool endlessUnlocked;
    public TMP_Text endlessText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClick()
    {
        SceneManager.LoadScene(1);
        Manager.instance.SetRoom(0);
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
}
