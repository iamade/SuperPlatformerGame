using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// handles the particle effects and other special effects for the game
/// </summary>

public class SFXCtrl : MonoBehaviour
{
    public static SFXCtrl instance; //allows other scripts to access public methods in this class without
   public SFX sfx;

    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    /// <summary>
    /// Shows the coin sparkle effect when the player collects the coin
    /// </summary>

    public void ShowCoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_pickup, pos, Quaternion.identity);
    }

    /// <summary>
    /// Shows the coin sparkle effect when the player collects the coin
    /// </summary>

    public void ShowBulletSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_bullet_pickup, pos, Quaternion.identity);
    }

    /// <summary>
    /// Shows the sparkle effects 
    /// </summary>

    public void ShowKillBulletSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_killbullet_pickup, pos, Quaternion.identity);
    }

    /// <summary>
    /// Shows the player dust particle effects 
    /// </summary>

    public void ShowPlayerLanding(Vector3 pos)
    {
        Instantiate(sfx.sfx_playerLands, pos, Quaternion.identity);
    }

    /// <summary>
    /// Shows the splash effect when player lands in water
    /// </summary>

    public void ShowSplash(Vector3 pos)
    {
        Instantiate(sfx.sfx_splash, pos, Quaternion.identity);
    }

    /// <summary>
    /// Shows the box breaking effect
    /// </summary>

    public void HandleBoxBreaking(Vector3 pos)
    {
        // position of the first fragment
        Vector3 pos1 = pos;
        pos1.x -= 0.3f;

        // position of the second fragment
        Vector3 pos2 = pos;
        pos2.x += 0.3f;

        // position of the third fragment
        Vector3 pos3 = pos;
        pos3.x -= 0.3f;
        pos3.x -= 0.3f;

        // position of the fourth fragment
        Vector3 pos4 = pos;
        pos4.x += 0.3f;
        pos4.x += 0.3f;

        //show the four broken fragments
        //these fragments or broken pieces have jump scripts attached
        // so after instantiation, they will jump apart

        Instantiate(sfx.sfx_fragment_1, pos, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_2, pos, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_2, pos, Quaternion.identity);
        Instantiate(sfx.sfx_fragment_1, pos, Quaternion.identity);

    }


}
