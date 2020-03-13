using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodController : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public LayerMask groundLayer;
    private bool lookingLeft = false;


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
        Health.health = 5;
        Powerup.isLarge = true;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (lookingLeft)
            {
                lookingLeft = !lookingLeft;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector2.left * speed * Time.deltaTime);
            if (!lookingLeft)
            {
                lookingLeft = !lookingLeft;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Death");
            Health.health = 3;
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
