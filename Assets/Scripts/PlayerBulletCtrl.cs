using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles the player's bullet movement and collision with the enemies
/// </summary>

public class PlayerBulletCtrl : MonoBehaviour
{
    public Vector2 velocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }
}
