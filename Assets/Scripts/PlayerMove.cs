using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;

    public Animator anim;

    public float velocity = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");

        print(h);

        /* Seta para direita, o valor do h vai até 1, somando um pouco na horizontal a cada frame
           Seta para esquerda, o valor do h vai para -1, dimuindo  um pouco a cada frama */

        rb.velocity = new Vector2(h * velocity, rb.velocity.y);

        //aponta a direção do movimento, personagem vai virar para onde direta ou esquerda

        if (h > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (h < 0)
        {

            transform.localScale = new Vector3(-1, 1, 1);
        }



        //Animação de movimento
        anim.SetBool("Run", Mathf.Abs(rb.velocity.x) > 0);
    }
}
