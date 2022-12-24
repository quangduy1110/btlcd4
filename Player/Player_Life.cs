using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Life : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        anim.SetTrigger("death");
    }


}
