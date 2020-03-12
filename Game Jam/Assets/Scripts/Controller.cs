using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{

    public float speed;
    public Vector2 jump;
    public LayerMask groundLayer;
    private bool lookingLeft = false;
    private bool isCrouching = false;
    public Animator anim;
    public BoxCollider2D p_collider;


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

        if((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && isGrounded())
        {
            anim.SetBool("isCrouching", true);
            isCrouching = true;
            p_collider.size = new Vector2(0.479f, 0.29f);
        }
        else
        {
            anim.SetBool("isCrouching", false);
            isCrouching = false;
            p_collider.size = new Vector2(0.479f, 0.45f);
        }

        if(Input.GetKeyDown(KeyCode.C) && Powerup.isLarge)
        {
            anim.SetBool("isLarge", false);
            gameObject.transform.localScale -= new Vector3(-3, 3, 3);
            Powerup.isLarge = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Tutorial");
            Health.health = 3;
        }
    }

    // Player Jump Movement function
    void Jump()
    {
        if (!isGrounded() || isCrouching)
        {
            return;
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(jump, ForceMode2D.Impulse);
        }
    }
}
