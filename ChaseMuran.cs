using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMuran : MonoBehaviour
{
    public Muran[] flyControlls;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Muran fly in flyControlls)
            {
                fly.chase = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (Muran fly in flyControlls)
            {
                fly.chase = false;
            }
        }
    }
}
