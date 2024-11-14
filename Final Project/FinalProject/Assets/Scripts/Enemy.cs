using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager scoreManager; // Stores the score manager in the scene
    public int scorePointsCarried; // The score points that will be given to the player upon the enemy's death

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>(); // Gets the active score manager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Called when the enemy has died
    private void OnDisable()
    {       
        scoreManager.IncreaseScore(scorePointsCarried); // Tells the score manager to increase the player's score by this enemy's score value
    }
}
