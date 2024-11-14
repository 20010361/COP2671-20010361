using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore; // The score the player currently has
    public TextMeshProUGUI scoreText; // The ui text that displays the player's score

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0; // Score starts at zero
        scoreText.text = "Score: " + currentScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Increases the player's score by the given parameter
    public void IncreaseScore(int scorePoints)
    {
        currentScore += scorePoints; // Adds the points to the player'score
        scoreText.text = "Score: " + currentScore;
    }
}
