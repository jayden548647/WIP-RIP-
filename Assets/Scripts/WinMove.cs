using UnityEngine;

public class WinMove : MonoBehaviour
{
    public int WinPosX;
    public int WinPosY;
    public float MoveCountdown;
    public bool MoveWin;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveCountdown = 12.7f;
        MoveMainWindowTo(960, 540);
        Application.runInBackground = true;
        MoveWin = Manager.instance.GetWinFreeze();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            MoveWin = !MoveWin;
            Manager.instance.SetWinFreeze(MoveWin);
        }
        if (MoveWin == true)
        {
            MoveCountdown -= Time.deltaTime;
            if (MoveCountdown <= 0)
            {
                WinPosX = Random.Range(0, 1920);
                WinPosY = Random.Range(0, 1080);
                MoveMainWindowTo(WinPosX, WinPosX);
                MoveCountdown = 1.27f;
            }
        }
        if(MoveWin == false)
        {
            MoveMainWindowTo(960, 540);
        }
    }
    void MoveMainWindowTo(int x, int y)
    {
        Screen.SetResolution(Screen.width, Screen.height, false);
        Vector2Int winP = new Vector2Int(x, y);
        DisplayInfo workArea = new DisplayInfo();
        Screen.MoveMainWindowTo(workArea, winP);
    }
}
