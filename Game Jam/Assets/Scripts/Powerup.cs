using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public Animator anim;
    public static bool isLarge = false;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D player)
    {
        anim.SetBool("isLarge", true);
        player.transform.localScale += new Vector3(-3, 3, 3);
        isLarge = true;
        Destroy(gameObject);
    }
}
