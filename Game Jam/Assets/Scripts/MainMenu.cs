using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Death");
        Health.health = 3;
        
    }

    public void Return ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
