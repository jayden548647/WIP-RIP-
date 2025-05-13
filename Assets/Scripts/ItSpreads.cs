using UnityEngine;

public class ItSpreads : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 spawn = new Vector2(0, 0);
        transform.position = spawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Antivirus()
    {
        Destroy(gameObject);
    }
}
