using UnityEngine;

public class SetRot : MonoBehaviour
{
    public float rng;
    public float rngCount;
    public float timer = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rng = Random.Range(0, 360);
        transform.Rotate(0, 0, rng);
        rngCount = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        rngCount -= Time.deltaTime;
        if(rngCount < timer)
        {
            rng = Random.Range(0, 360);
            transform.Rotate(0, 0, rng);
            rngCount = Random.Range(1, 5);
        }
    }
}
