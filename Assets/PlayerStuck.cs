using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Check When the player is stuck
/// </summary>
public class PlayerStuck : MonoBehaviour
{
    public GameObject player;  //to get access to the PlayerCtrl script

    PlayerCtrl playerCtrl;     // to reference the PlayerCtrl script

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        playerCtrl.isStuck = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        playerCtrl.isStuck = false;
    }
}

