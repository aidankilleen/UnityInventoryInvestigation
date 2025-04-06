using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameState", menuName = "Game/Game State")]
public class GameManagerWithInventory : ScriptableObject
{

    public List<string> inventoryItems = new List<string>();
    public List<string> activatedTriggers = new List<string>();

    public void AddItem(string item)
    {
        if (!inventoryItems.Contains(item))
        {
            inventoryItems.Add(item);
            Debug.Log("Item added to inventory: " + item);
        }
        else
        {
            Debug.Log("Item already in inventory: " + item);
        }
    }
    public bool HasItem(string item)
    {
        return inventoryItems.Contains(item);
    }

    public void ActivateTrigger(string trigger)
    {
        if (!activatedTriggers.Contains(trigger))
        {
            activatedTriggers.Add(trigger);
            Debug.Log("Trigger activated: " + trigger);
        }
        else
        {
            Debug.Log("Trigger already activated: " + trigger);
        }
    }
    public bool IsTriggerActivated(string trigger)
    {
        return activatedTriggers.Contains(trigger);
    }
}