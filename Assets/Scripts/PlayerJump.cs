using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody2D rb;

    public float JumpForce = 50f;

    bool inGround;

    public float distance = 1;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && inGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * JumpForce);
        }
    }
    private void FixedUpdate()
    {
        inGround = Physics2D.Raycast(transform.position, Vector2.down, distance, 1 << LayerMask.NameToLayer("Ground"));
        Debug.DrawRay(transform.position, Vector2.down * distance, inGround ? Color.blue : Color.red);
        // ? representa se, e o : se não

        //transfrm position é a posição do jogador  , vetor de posição para baixo vezes a distance, e tambem a layer mask

    }
}
