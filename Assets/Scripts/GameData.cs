using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;     //give access to the [Serializable] attribute

/// <summary>
/// The Data Model for your game data
/// </summary>

[Serializable]
public class GameData
{
    public int coinCount; //tracks the number of coins collected
}
