using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float moveSpeed = 20f;
    public float dashSpeed = 30f;
    float dirX;
    float dirY;
    public float minWidth;
    public float maxWidth;

    public UnityEngine.GameObject dashEffect;

    public bool isAcelerated = true;




    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minWidth, maxWidth), transform.position.y);

        if (isAcelerated)
        {
            dirX = Input.acceleration.x * moveSpeed;
            //dirY = Input.acceleration.y * moveSpeed;

            
        }
        else
        {
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 temp = new Vector3(horizontal, vertical, 0);
            temp = temp.normalized * moveSpeed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + temp);
            if(vertical > 0)
            {
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                Debug.Log("Dash");
            }
            
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            rb.AddForce(new Vector2(0f, dashSpeed), ForceMode2D.Force);
            Instantiate(dashEffect,transform.position,Quaternion.identity);
            Debug.Log("Dash");
            
        }


        
       
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX,0f);
    }
}
