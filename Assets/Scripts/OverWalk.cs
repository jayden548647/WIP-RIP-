using UnityEngine;

public class OverWalk : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x <= -19)
        {
            transform.position = player.transform.position + new Vector3 (220, 350, 10);
        }
        if(player.transform.position.x > -19)
        {
            transform.position = player.transform.position + new Vector3 (-200, -200, 0);
        }
    }
}
