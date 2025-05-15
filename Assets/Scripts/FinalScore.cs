using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TMP_Text finalJudgement;
    public int score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = Random.Range(0, 1234567890);
    }

    // Update is called once per frame
    void Update()
    {
        finalJudgement.text = "Final Score: " + score;
    }
}
