using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyControll : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public GameObject player;
    public Transform startingpoint;




    // Start is called before the first frame update
   private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (chase==true)
        {
            Chase();
        }
        if (player == null)
        {
            return;
        }
        
        else
        {
            ReturnStartPoint();
        }
        
        Flip();
        
    }
    public void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position,speed*Time.deltaTime);

    }
    public void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingpoint.position, speed * Time.deltaTime);
    }
}
