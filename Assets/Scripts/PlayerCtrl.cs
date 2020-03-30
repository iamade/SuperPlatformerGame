using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1. Make the player move left to right, jump, fliping
/// 2. Player Animations
/// </summary>
public class PlayerCtrl : MonoBehaviour
{

    /*Idle = 0
      Running = 1
      Jumping  = 2
      Falling = 3
      Hurt = -1

    */

    [Tooltip("this is a positive integer which speeds up the player movement")]
    public int speedBoost; //set to 5
    public float jumpSpeed; //set this to 600
    public bool isGrounded, canDoubleJump;
    public Transform feet;
    public LayerMask whatIsGround;
    public float feetRadius;
    public float boxWidth;
    public float boxHeight;
    public float delayForDoubleJump;
    public Transform leftBulletSpawnPos, rightBulletSpawnPos;
    public GameObject leftBullet, rightBullet, leftKillBullet, rightKillBullet;
    public bool SFXOn;
    public bool canFire, canKill;
    public bool isJumping, isStuck;


    public bool leftPressed, rightPressed; 


    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        // isGrounded = Physics2D.OverlapCircle(feet.position, feetRadius, whatIsGround);

        isGrounded = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth,boxHeight), 360.0f, whatIsGround);


        float playerSpeed = Input.GetAxisRaw("Horizontal"); //value will be 1, 1 0r 0
        playerSpeed *= speedBoost; 
        if (playerSpeed != 0)
            MoveHorizontal(playerSpeed);
        else
            StopMoving();

        if (Input.GetButtonDown("Jump"))
            jump();

        if (Input.GetButtonDown("Fire1"))
        {
            FireBullets();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            FireKillBullets();
        }

        ShowFalling();

        if (leftPressed)
            MoveHorizontal(-speedBoost);

        if (rightPressed)
            MoveHorizontal(speedBoost);

    }

    private void OnDrawGizmos()
    {
       // Gizmos.DrawWireSphere(feet.position, feetRadius);

        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));
    }

    void MoveHorizontal(float playerSpeed)
    {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);

        if (playerSpeed < 0)
            sr.flipX = true;
        else if (playerSpeed > 0)
            sr.flipX = false;
        if(!isJumping)
            anim.SetInteger("State", 1);
    }

   
    void StopMoving()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
      
        if (!isJumping)
            anim.SetInteger("State", 0);

    }

    void jump()
    {
        if (isGrounded)
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpSpeed)); //simply jump in the y axis
            anim.SetInteger("State", 2);


            Invoke("EnableDoubleJump", delayForDoubleJump);
        }

        if(canDoubleJump && !isGrounded)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed)); //simply jump in the y axis
            anim.SetInteger("State", 2);

            canDoubleJump = false;
        }

    }

    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                GameCtrl.instance.UpdateCoinCount();
                if(SFXOn)
                    SFXCtrl.instance.ShowCoinSparkle(other.gameObject.transform.position);
                break;
            case "Water":
                //show the splash effect
                SFXCtrl.instance.ShowSplash(other.gameObject.transform.position);

                //inform the GameCtrl
                GameCtrl.instance.PlayerDrowned(gameObject);
                break;
            case "Powerup_Bullet":
                canFire = true;
                Vector3 powerupPos = other.gameObject.transform.position;
                Destroy(other.gameObject);
                if (SFXOn)
                    SFXCtrl.instance.ShowBulletSparkle(powerupPos);
                    Debug.Log("Cat picks up Power Bullet");
                break;
            case "Powerup_KillBullet":
                canKill = true;
                Vector3 killPowerupPos = other.gameObject.transform.position;
                Destroy(other.gameObject);
                if (SFXOn)
                    Debug.Log("Cat picks up Power KILL Bullet");
                    SFXCtrl.instance.ShowBulletSparkle(killPowerupPos);
                break;
            default:
                break;
        }
    }

    void FireBullets()
    {
        if (canFire)
        {
            // makes the player fire bullets in the left direction
            if (sr.flipX)
            {
                Instantiate(leftBullet, leftBulletSpawnPos.position, Quaternion.identity);
            }

            // makes the player fire bullets in the right direction

            if (!sr.flipX)
            {
                Instantiate(rightBullet, rightBulletSpawnPos.position, Quaternion.identity);
            }
        }

    }

    void FireKillBullets()
    {
        if (canKill)
        {
            // makes the player fire kill bullets in the left direction
            if (sr.flipX)
            {
                Instantiate(leftKillBullet, leftBulletSpawnPos.position, Quaternion.identity);
            }


            // makes the player fire kill bullets in the right direction

            if (!sr.flipX)
            {
                Instantiate(rightKillBullet, rightBulletSpawnPos.position, Quaternion.identity);
            }
        }
        

    }

    public void MobileMoveLeft()
    {
        leftPressed = true;
    }

    public void MobileMoveRight()
    {
        rightPressed = true;
    }

    public void MobileStop()
    {
        leftPressed = false;
        rightPressed = false;

        StopMoving();
    }

    public void MobileFireBullets()
    {
        FireBullets();
    }

    public void MobileFireKillBullets()
    {
        FireKillBullets();
    }

    void ShowFalling()
    {
        if(rb.velocity.y < 0)
        {
            anim.SetInteger("State", 3);
        }
    }

    public void MobileJump()
    {
        jump();
    }
}
