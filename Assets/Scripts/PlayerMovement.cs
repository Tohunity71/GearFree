using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [HideInInspector]public int jumps;
    public float jumpHeight;
    private bool isGrounded;
    public Rigidbody2D rb;
    

    private bool facingRight;

    private void Awake()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float Horizontal = (Input.GetAxis("Horizontal"));      
        Vector3 movement = new Vector3(Horizontal, 0f, 0f); ;
        transform.position += movement * Time.deltaTime * moveSpeed;
        Flip(Horizontal);

        //Jump
        if (Input.GetButtonDown("Jump") && jumps < 1)
        {
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
            jumps++;
        }

        Debug.Log(jumps);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }


    // Jump check
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Gear")
        {
            jumps = 0;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Collission with ground
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "Gear")
        {
            isGrounded = false;
        }
    }

}
