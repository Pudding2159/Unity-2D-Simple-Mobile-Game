using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ladder_player : MonoBehaviour
{
    // Start is called before the first frame update
    private float vertical;
    public float speed = 1f;
    private bool isLadder;
    private bool isClimbin;
    public float gravi  = 2f;
    public Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            isLadder = true;

        } 
    }



    private void OnTriggerExit2D(Collider2D collision) 
    {

        if(collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbin = false;
            
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //vertical = Input.GetAxis("Vertical");
        //Debug.Log(vertical);
    
    
        // if(isLadder && Mathf.Abs(vertical) > 0f)
        // {

        //     isClimbin = true;
        // }

        if(isClimbin == true)
            animator.SetBool("Ladder_", true);
        else
            animator.SetBool("Ladder_", false);

    }

    public void OnRightButtonLadder()
    {
        if(isLadder)
        {
            isClimbin = true;
        }

        vertical = 0.99f;
    }


    public void OnRightDownLadder()
    {
        vertical = 0f;
    }

    private void FixedUpdate() 
    {
        if(isClimbin)
        {
            ///gravi = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
            rb.AddForce(Vector2.up * vertical * speed); // Add force for climbing the ladder

        }
        else
        {
            rb.gravityScale =gravi;

        }
    }
}
