using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides the parallax effect
/// </summary>

public class Parallax : MonoBehaviour
{

    public GameObject player;
    public float speed; //speed at which the BG moves. set this to 0.001

    float offSetX; //this is the secret to horizontal parallax
    Material mat; // this is the material attached to the renderer of the Quad
    PlayerCtrl playerCtrl;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    // Update is called once per frame
    void Update()
    {
        // offSetX += 0.005f;

        if (!playerCtrl.isStuck)
        {
            //shows the parallax
            //handles the keyboard and joystick
            offSetX += Input.GetAxisRaw("Horizontal") * speed;

            //handles the mobile parallax
            if (playerCtrl.leftPressed)
                offSetX += -speed;
            else if (playerCtrl.rightPressed)
                offSetX += speed;
            mat.SetTextureOffset("_MainTex", new Vector2(offSetX, 0));

        }
        
    }
}
