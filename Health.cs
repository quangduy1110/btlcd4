using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioSource audiohurt;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            audiohurt.Play();
            anim.SetTrigger("hurt");
            //iframes
        }
        else
        {
            if (!dead)
            {
                
                anim.SetTrigger("die");
                audio.Play();
                GetComponent<PlayerCtr>().enabled = false;
                dead = true;

            }
        }
    }
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
    public void CheckRepawn()
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
