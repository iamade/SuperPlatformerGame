using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles the triangle bullet
/// 
/// </summary>

public class TriangleBulletCtrl : MonoBehaviour
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
