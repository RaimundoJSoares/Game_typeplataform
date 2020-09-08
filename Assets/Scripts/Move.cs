using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Velocity = 1f;

    public Vector2 direction = Vector2.right;

    public bool reversedirection;

    public float inverttime = 1f;

    int newdirection = 1;

    private void Start()
    {
        if (reversedirection)
        {

            InvokeRepeating("Reversedirection", inverttime, inverttime);
        }

    }
    void Reversedirection()
    {
        newdirection *= -1;

    }


    private void Update()

    {

        transform.Translate(direction * Velocity * newdirection * Time.deltaTime);
    }
}
