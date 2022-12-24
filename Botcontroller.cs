using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Botcontroller : MonoBehaviour
{
    //[SerializeField] float moveSpeed = 1.0f;
    //Rigidbody2D rigidbody2D;
    //BoxCollider2D boxCollider2D;
    public float speed=2f;
    public float raydist=2f;
    public bool moveright;
    public Transform grounddef;


    public List<Transform> points;
    public int nextid;
    int idchangvalus=1;






    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        RaycastHit2D groucheck = Physics2D.Raycast(grounddef.position, Vector2.down, raydist);
        if (groucheck.collider == false)
        {
            if (moveright)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                
                

                moveright = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                moveright = true;
            }
        }


        //if (IsFacingRight())
        //{
        //    rigidbody2D.velocity = new Vector2(moveSpeed, 0f);

        //}
        //else
        //{
        //    rigidbody2D.velocity = new Vector2(-moveSpeed, 0f);
        //}
    }
    //public bool IsFacingRight()
    //{
    //    return transform.localScale.x > Mathf.Epsilon;
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)),transform.localScale.y);
    //}
}
