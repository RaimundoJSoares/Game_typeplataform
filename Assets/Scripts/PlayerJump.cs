using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerJump : MonoBehaviour
{
    //Head organiza variáveis
    [Header("Components")]
    public Rigidbody2D rb;

    [Header("Configurations")]

    public float JumpForce = 50f;

    bool doublejumpAvaliable = true;


    [Header("GroundDetectors")]

    public float distance = 1;

    bool inGround;

    public Transform GroundDetector1;

    public Transform GroundDetector2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && doublejumpAvaliable)
        {
            if (!inGround)
            {           //if he IS NOT  in the ground, he already used the doublejump, so you can't until down
                doublejumpAvaliable = false;
            }
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce);
        }
        Debug.DrawRay(GroundDetector1.position, Vector2.down * distance, inGround ? Color.blue : Color.red);
        Debug.DrawRay(GroundDetector2.position, Vector2.down * distance, inGround ? Color.blue : Color.red);
    }
    private void FixedUpdate()
    {
        inGround = Physics2D.Raycast(GroundDetector1.position, Vector2.down, distance, 1 << LayerMask.NameToLayer("Ground"))
        || Physics2D.Raycast(GroundDetector2.position, Vector2.down, distance, 1 << LayerMask.NameToLayer("Ground"));

        if (inGround && !doublejumpAvaliable)   //Important, need to use this because when you back to ground after double jump, you can use double jump again.
        {
            doublejumpAvaliable = true;
        }


        // ? representa se, e o : se não

        //transfrm position é a posição do jogador  , vetor de posição para baixo vezes a distance, e tambem a layer mask

    }
}
