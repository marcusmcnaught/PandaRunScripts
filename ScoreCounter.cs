using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public int score ;
    public TextMeshProUGUI scoreText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "Score - " + score;
    }
    
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score - " + score;
    }
}
