using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Health : MonoBehaviour
{
    public float maxhealth = 3;
    public float current_health;
    public Animator animator;
    public GameObject gameob;

    // Start is called before the first frame update
    void Start()
    {
        current_health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Take_Dame(float dame)
    {
        current_health -= dame;
        animator.SetTrigger("Bot_Hurt");
        if (current_health<=0)
        {
            Die();
        }

    }
    void Die()
    {
        animator.SetBool("IsDead",true);
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
        

    }
    void DeadOB()
    {
        Destroy(gameob);
    }
}
