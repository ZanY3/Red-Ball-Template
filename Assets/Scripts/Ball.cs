using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float jump;
    public float moveForce;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(hor, 0);
        rb.AddForce(new Vector3(hor, 0) * moveForce);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * jump;
        }
        
    }
}
