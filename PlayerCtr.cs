using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtr : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] public float speed = 1.5f;
    [SerializeField] public float jumpPower = 150;
    [SerializeField] Transform groundcheckcollider;
    const float groundradius = 0.2f;
    [SerializeField] LayerMask groundlayer;
    public Rigidbody2D rigidbody;
    float horizontalValues;
    Animator animator;
    float runSpeedModifier = 2f;
    [SerializeField] bool isRuning;
    bool facingRight = true;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] AudioSource jumpaudio;



    // Update is called once per frame
    void Update()
    {
        horizontalValues = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRuning = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRuning = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            jumpaudio.Play();
            jump = true;
            animator.SetBool("Jump", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
            animator.SetBool("Jump", false);
        }
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()

    {
        Groundcheck();
        Move(horizontalValues, jump);

    }
    void Groundcheck()
    {
        isGrounded = false;
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(groundcheckcollider.position, groundradius, groundlayer);
        if (collider2Ds.Length > 0)
        {
            isGrounded = true;
        }
    }
    void Move(float dir, bool jumpflag)

    {
        if (isGrounded && jumpflag)
        {
            isGrounded = false;
            jumpflag = false;
            rigidbody.AddForce(new Vector2(0f, jumpPower));


        }
        float xvalues = dir * speed * 100 * Time.deltaTime;
        if (isRuning)
        {
            xvalues *= runSpeedModifier;
        }
        Vector2 targetVelocity = new Vector2(xvalues, rigidbody.velocity.y);
        rigidbody.velocity = targetVelocity;



        Vector3 curenScale = transform.localScale;
        if (facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            facingRight = false;
        }
        else if (!facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            facingRight = true;
        }
        curenScale = transform.localScale;
        animator.SetFloat("xVelocity", Mathf.Abs(rigidbody.velocity.x));

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
        animator.SetTrigger("death");

    }
    public bool canAttack()
    {

        return horizontalValues == 0;
    }
  
}
