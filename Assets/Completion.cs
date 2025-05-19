using UnityEngine;

public class Completion : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       if(Manager.instance.GetBillOver() == false)
        {
            sr.color = Color.clear;
        }
       if(Manager.instance.GetBillOver() == true)
        {
            sr.color = Color.yellow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
