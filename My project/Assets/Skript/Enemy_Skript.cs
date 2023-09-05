using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skript : MonoBehaviour
{


    private Rigidbody2D physic;
    public Transform player;

    private float HorizontalMove;

    public Animator animator;
    public float speed = 1f;
    public float distAgro = 2f;
    // Start is called before the first frame update
    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
        physic.gravityScale = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        // HorizontalMove = Input.GetAxisRaw("Horizontal") * speed; 

        // animator.SetFloat("horizontal_move_Enemy", Mathf.Abs(HorizontalMove));

        float disttoPlayer = Vector2.Distance(transform.position, player.position);
        //Debug.Log("distance:" + disttoPlayer);


        if(disttoPlayer < distAgro && disttoPlayer > 0.5f)
        {
            StartHunt();
        }
        else
        {
            StopHunt();
        }

    }



    private void StopHunt()
    {
        physic.velocity = new Vector2(0,0);
        animator.SetFloat("horizontal_move_Enemy", 1);
    }


    private void StartHunt()
    {
        if(player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1,1);
            physic.velocity = new Vector2(-speed,0);
            HorizontalMove = -speed;

        }
        else
        {
            transform.localScale = new Vector2(1,1);
            physic.velocity = new Vector2(speed,0);
            HorizontalMove = speed;
        }
        animator.SetFloat("horizontal_move_Enemy", 0);
    }
}
