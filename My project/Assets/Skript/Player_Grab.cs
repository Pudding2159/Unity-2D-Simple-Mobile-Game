 using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Player_Grab : MonoBehaviour
{

    public float targetY = 5.0f; // Целевая высота, на которую вы хотите поднять персонажа
    public float speed = 2.0f;   // Скорость поднятия
    private bool greenBox, redBox;

    public float redXoffset,redYoffset , redXSize,redYSize , greenXoffset, greenYoffset, greenXSize, greenYsize;
    
    public LayerMask groundMask;
    private Rigidbody2D rb;


    void Start() 
    { 
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        greenBox = Physics2D.OverlapBox(new Vector2(transform.position.x 
        + (greenXoffset * transform.localScale.x),transform.position.y + greenYoffset), new Vector2(greenXSize,greenYsize), 0f, groundMask);


        redBox = Physics2D.OverlapBox(new Vector2(transform.position.x
        + (redXoffset * transform.localScale.x),transform.position.y + redYoffset), new Vector2(redXSize,redYSize), 0f, groundMask);
    
    
        if (greenBox && !redBox)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
    
    
    }
    
    private void OnDrawGizmosSelected() {

        Gizmos.color = Color.red;
        Vector3 position = new Vector3(transform.position.x + (redXoffset * transform.localScale.x),
                                       transform.position.y + redYoffset, 
                                       transform.position.z);

        Vector3 size = new Vector3(redXSize, redYSize, 0f);

        Gizmos.DrawWireCube(position, size);
    
        Gizmos.color = Color.green;
            Vector3 position1 = new Vector3(transform.position.x + (greenXoffset * transform.localScale.x),
                                        transform.position.y + greenYoffset, 
                                        transform.position.z);

            Vector3 size1 = new Vector3(greenXSize, greenYsize, 0f);

            Gizmos.DrawWireCube(position1, size1);
    }

    




}
