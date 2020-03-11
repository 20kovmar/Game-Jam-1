using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (Input.GetKey(KeyCode.Z) && !(Powerup.isLarge)))
        {
            
                Advance();
        }
    }

    void Advance()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
