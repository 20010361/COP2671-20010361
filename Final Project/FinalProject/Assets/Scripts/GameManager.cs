using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Applys damage to a game object
    public void ApplyDamageToVictim(float damage, GameObject victim)
    {
        HealthSystem healthSystem = victim.GetComponent<HealthSystem>(); // Gets the health component of victim object
        healthSystem.ApplyDamage(damage); // Applies damage to object health
    }
}
