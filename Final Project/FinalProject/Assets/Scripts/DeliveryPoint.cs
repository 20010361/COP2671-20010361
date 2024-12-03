using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    // Executes upon something colliding with the delivery point
    private void OnTriggerEnter(Collider other)
    {
        // Executes if the collidiing object is the player
        if(other.gameObject.CompareTag("Player"))
        {
            // Executes if the player inventory is full
            if(other.gameObject.GetComponent<Inventory>().bIsEmpty == false)
            {
                other.gameObject.GetComponent<Inventory>().RemoveFromInventory(); // Uses the powerup and removes it from inventory
            }
        }
    }
}
