using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : PowerUpEffect
{
    private ScoreManager scoreManager; // Stores the score manager in the scene
    private int scoreToAdd = 2000; // The points added to the score


    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("GameManager").GetComponent<ScoreManager>(); // Gets the active score manager
    }

    // Activates the powerup
    public override void EnablePower()
    {
        scoreManager.IncreaseScore(scoreToAdd); // Adds to the score
    }
}
