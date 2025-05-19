using UnityEngine;

public class GameBeat : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Manager.instance.GetEndlessUnlock() == false)
        {
            sr.color = Color.clear;
        }
        if(Manager.instance.GetEndlessUnlock() == true)
        {
            sr.color = Color.magenta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
