using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int highScore;
    public static int score;
    
    public GameObject player;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    
    public float timeBetweenIncrements = 0.75f;
    private float timePassed;
    
    void Start()
    {
        score = 0;
        timeBetweenIncrements = 0.75f;
        timePassed = 0f;
        highscoreText.text = highScore.ToString();
    }
        
    void Update()
    {
        if (player ==null) { return; }
        
        timePassed += Time.deltaTime;
        if (timePassed >= timeBetweenIncrements)
        {
            score += 1;
            scoreText.text = score.ToString();
            timePassed = 0f;

            if (score <= highScore) { return; }
            highScore = score;
            highscoreText.text = highScore.ToString();
        }
    }
}
