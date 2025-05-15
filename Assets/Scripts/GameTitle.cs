using UnityEngine;
using TMPro;

public class GameTitle : MonoBehaviour
{
    public bool gameBeat;
    public Animator animator;
    public float highScore;
    public TMP_Text score;
    public GameObject billianMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameBeat = Manager.instance.GetEndlessUnlock();
        highScore = Manager.instance.GetHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Beaten", gameBeat);
        if(highScore <= 0)
        {
            score.color = Color.clear;
        }
        else
        {
            score.color = Color.yellow;
            score.text = "Endless Record: " + highScore;
        }
        if(Manager.instance.GetUnlockBillian() == true)
        {
            billianMode.SetActive(true);
        }
    }
}
