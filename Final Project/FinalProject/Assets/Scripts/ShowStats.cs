using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowStats : MonoBehaviour
{
    private RoundManager roundManager; // The current round manager
    private ScoreManager scoreManager; // The current score manager

    public TextMeshProUGUI roundText; // Text to show current round
    public TextMeshProUGUI scoreText; // Text to show current score

    // Start is called before the first frame update
    void Start()
    {
        // Finds the round and score managers
        roundManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<RoundManager>();
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").gameObject.GetComponent<ScoreManager>();
    }

    // Displays the round and score
    public void Show()
    {
        roundText.text = "Current Round: " + roundManager.currentRound;
        scoreText.text = "Score: " + scoreManager.currentScore;     
    }
}
