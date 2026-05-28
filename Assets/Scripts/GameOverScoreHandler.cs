using TMPro;
using UnityEngine;

public class GameOverScoreHandler : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    
    void Start()
    {
        highScoreText.text = Score.highScore + " best";
        scoreText.text = Score.score + " score";
    }
}
