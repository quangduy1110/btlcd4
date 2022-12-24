using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    [SerializeField] private float attackCooldown=0.5f;

    [SerializeField] private Transform attackpoint;
    //[SerializeField] private GameObject[] fireballs;
    public LayerMask enemyLayer;
    public Animator anim;
    [SerializeField] private float attack_rage =0.5f;
    private PlayerCtr playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    public float dame = 1.0f;
    [SerializeField]
    private AudioSource source;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerCtr>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMovement.canAttack())
        {
            Attack();
        }
          

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        source.Play();
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        Collider2D[] hitEnemy=Physics2D.OverlapCircleAll(attackpoint.position, attack_rage, enemyLayer);

        foreach(Collider2D enemy in hitEnemy)
        {
            enemy.GetComponent<Bot_Health>().Take_Dame(dame);

        }



        //fireballs[FindFireball()].transform.position = firePoint.position;
        //fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    //private int FindFireball()
    //{
    //    for (int i = 0; i < fireballs.Length; i++)
    //    {
    //        if (!fireballs[i].activeInHierarchy)
    //            return i;
    //    }
    //    return 0;
    //}
    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackpoint.position, attack_rage);
    }
}

