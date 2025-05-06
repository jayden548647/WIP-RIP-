using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform player;

    public float followSpeed = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 newPos = new Vector3(player.position.x, player.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
