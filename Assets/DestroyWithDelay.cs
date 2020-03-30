using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Destroys the gameobject after a specified delay
/// </summary>
/// 
public class DestroyWithDelay : MonoBehaviour
{
    public float delay; //set to 1.5

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, delay);
    }

   
}
