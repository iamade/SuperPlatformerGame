using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour
{
    public GameObject player;

    PlayerCtrl playerCtrl;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }

    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }

    public void MobileStop()
    {
        playerCtrl.MobileStop();
    }
    public void MobileFireBullets()
    {
        playerCtrl.MobileFireBullets();
    }

    public void MobileFireKillBullets()
    {
        playerCtrl.MobileFireKillBullets();
    }

    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
}
