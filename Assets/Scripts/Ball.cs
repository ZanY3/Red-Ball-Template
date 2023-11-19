using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Ball : MonoBehaviour
{
    public float jump;
    public float moveForce;
    Rigidbody2D rb;
    bool isGrounded;

    public float partCount;
    public GameObject particle;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }


    void Update()
    {
        var hor = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector3(hor, 0);
        rb.AddForce(new Vector3(hor, 0) * moveForce );

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += Vector2.up * jump;
        }
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;

        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            for (int i = 0; i < partCount; i++)
            {
                var offset = Random.insideUnitSphere;
                Instantiate(particle, transform.position + offset, transform.rotation);
            }
            FindObjectOfType<GameManager>().Lose();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Contains("Teleporter"))
        {
            FindObjectOfType<GameManager>().Win();
        }
    }
}
