using System.Collections;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject player;
    public TMP_Text scoreText;
    
    public int score = 0;
    public float timeBetweenIncrements = 0.4f;
    private float timePassed = 0f;
        
    void Start()
    {
        while (player != null)
        {
            timePassed += Time.deltaTime;
            if(timePassed >= timeBetweenIncrements)
            {
                if (player != null)
                {
                    score += 1;
                    scoreText.text = score.ToString();
                    timePassed = 0f;
                }
                else
                {
                    break;
                }
                
            } 
            
        }
    }
}
