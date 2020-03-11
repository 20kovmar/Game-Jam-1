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
    public float speed;
    private Vector3 pos1;
    private Vector3 pos2;
    public Vector3 posDiff = new Vector3(10f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + posDiff;
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
        transform.position = Vector3.Lerp(pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);


    }

    public void Die (){
      Destroy(gameObject);
      Destroy(obj);
    }

}
