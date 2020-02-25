﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public LayerMask groundLayer;
    private bool lookingLeft = false;
    private bool isLarge = false;
    

    // Checks if Player is on the ground currently
    bool isGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (lookingLeft)
            {
                lookingLeft = !lookingLeft;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector2.left * speed * Time.deltaTime);
            if (!lookingLeft)
            {
                lookingLeft = !lookingLeft;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!isLarge)
            {
                gameObject.transform.localScale += new Vector3(1, 1, 1);
                isLarge = true;
            }
            else if (isLarge)
            {
                gameObject.transform.localScale -= new Vector3(1, 1, 1);
                isLarge = false;
            }
                
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Player Jump Movement function
    void Jump()
    {
        if (!isGrounded())
        {
            return;
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
        }
    }
}
