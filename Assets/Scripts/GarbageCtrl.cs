using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCtrl : MonoBehaviour
{
    /// <summary>
    /// Destroys any gameobject that comes in contact with it
    /// For the player, the level is restarted
    /// </summary>

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameCtrl.instance.PlayerDied(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
        
    }
}
