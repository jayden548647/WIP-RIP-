using UnityEngine;
using TMPro;

public class GameBeat : MonoBehaviour
{
    public SpriteRenderer sr;
    public TMP_Text ver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Manager.instance.GetEndlessUnlock() == false)
        {
            sr.color = Color.clear;
            ver.text = "Ver 0.12.7";
        }
        if(Manager.instance.GetEndlessUnlock() == true)
        {
            sr.color = Color.magenta;
            ver.text = "Ver 1.27";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
