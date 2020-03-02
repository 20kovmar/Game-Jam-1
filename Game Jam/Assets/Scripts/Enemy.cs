using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth;
    public GameObject obj;
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void TakeDamage (int Damage){
      currentHealth -= Damage;
      if(currentHealth <= 0){
        Destroy(healthBar);
        Die();
      }
    }

    float CalculateHealth(){
      return currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      healthBar.value = CalculateHealth();
    }

    public void Die (){
      Destroy(gameObject);
      Destroy(obj);
    }
}
