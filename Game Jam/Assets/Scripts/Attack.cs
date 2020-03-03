using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float attackTime;
    public float startAttackTime;
    public Transform attackPos;
    public float attackRange;
    public LayerMask enemyLayer;
    public int damage;
    public Animator animator;

    private bool attacking = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.X) && !attacking && Controller.isLarge)
            {
                animator.SetTrigger("isAttacking");
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayer);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                attackTime = startAttackTime;
            }
        }
        else
        {
            attackTime -= Time.deltaTime;
            animator.ResetTrigger("isAttacking");
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
