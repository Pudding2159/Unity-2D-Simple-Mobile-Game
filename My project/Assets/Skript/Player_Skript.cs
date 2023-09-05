using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Skript : MonoBehaviour
{

    private bool canDash =true;
    private bool isDasing;
    public float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    public float speed = 0.10f;
    public float two_speed = 0.10f;
    public  bool FacingRight = true;


    private int jumpCount = 0;
    public int maxJumpCount = 1; // Максимальное количество прыжков

    public float jumpForce = 8f;
    private Vector3 lastPosition_Y;

    public Animator animator;

    [Header("Ground Checker Setting")]
    public bool isGrounded = false;
    [Range(-10f,10f)] public float checkGroundOffY = -1.8f;
    [Range(-10f,10f)] public float checkGroundradis = 0.3f; 
    [SerializeField] private TrailRenderer tr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPosition_Y = transform.position;
        Application.targetFrameRate = -1;
        Application.targetFrameRate = 120;
    }


    void Update()
    {   
        if (isGrounded)
        {
        jumpCount = 0;
        animator.SetBool("Jump", false);
        }

        if(isDasing)
        {
            animator.SetBool("Dash_", true);
        }
        else
        {
          animator.SetBool("Dash_", false);  
        }
        if(isDasing)
        {
            return;   
        }

        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump")) && jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Сбросьте вертикальную скорость перед каждым прыжком.
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            animator.SetBool("Jump", true);
        }

        // HorizontalMove = Input.GetAxisRaw("Horizontal") * speed; 
        
        animator.SetFloat("horizontal_move", Mathf.Abs(HorizontalMove));

        if(isGrounded == false){
            animator.SetBool("Jump",true);
        }
        else
            animator.SetBool("Jump", false);



        // if(HorizontalMove < 0 && FacingRight)
        //     Flip();
        // else if(HorizontalMove > 0 && !FacingRight)
        //     Flip();

        Debug.Log("IsGrounded:" + isGrounded);


        // if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        // {
        //     StartCoroutine(Dash());          
        // }
    
    //-7.10, 31.13, 0.07
        // if(isDasing)
        // {
        //     return;   
        // }
        // Vector2 targetVelosyty = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        // rb.velocity = targetVelosyty;
        // checkGround();
    }

    public void OnRightButtonDash()
    {
        StartCoroutine(Dash());
    }


    void FixedUpdate()
    {
        if(isDasing)
        {
            return;   
        }
        Vector2 targetVelosyty = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelosyty;
        checkGround();
    }


    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }



    public void OnJumpButtonDown()
    {
        if (isGrounded || jumpCount < maxJumpCount)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            animator.SetBool("Jump", true);
        }
    }


    public void OnLeftButtonDown()
    {
        HorizontalMove = -speed;
        if(HorizontalMove < 0 && FacingRight)
            Flip();
        rb.velocity = new Vector2(HorizontalMove, rb.velocity.y);
            

    }


    public void OnRightButtonDown()
    {
        HorizontalMove = speed;
        if(HorizontalMove > 0 && !FacingRight)
            Flip();
        rb.velocity = new Vector2(HorizontalMove, rb.velocity.y);

    }



    public void OnRightButtonUP()
    {
        HorizontalMove = 0f;
    }

    private void checkGround()
    {
        Vector2 center = new Vector2(transform.position.x, transform.position.y + checkGroundOffY);

        // Рисуем окружность в сцене Unity

        Collider2D[] colliders =  Physics2D.OverlapCircleAll(new Vector2(transform.position.x,
        transform.position.y + checkGroundOffY), checkGroundradis);

        if(colliders.Length > 1 )
        {
            isGrounded = true; 
        }
        else       
        {
           isGrounded = false; 
        }
       

    }

    private void OnDrawGizmos()
    {
        // Calculate the center of the sphere
        Vector3 center = new Vector3(transform.position.x, transform.position.y + checkGroundOffY, transform.position.z);

        // Set the color for the wire sphere
        Gizmos.color = Color.red;

        // Draw the wire sphere
        Gizmos.DrawWireSphere(center, checkGroundradis);
    }


    
    private IEnumerator Dash()
    {
        canDash = false;
        isDasing = true;
        float originalFravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalFravity;
        isDasing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
        tr.emitting = false;
    }


}



