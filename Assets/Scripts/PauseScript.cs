using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        if (Manager.instance.GetRoom() != 127)
        {
            Time.timeScale = 0f;
        }
    }
    
        
    
}
