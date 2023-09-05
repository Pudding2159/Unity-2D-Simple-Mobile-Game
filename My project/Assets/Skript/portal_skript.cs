using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal_skript : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Transform destination;
    private GameObject currentTeleport;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<portal_skript_1>().GetDestination().position;
            }

        }
    }

    public void OnRightDownMenu()
    {
        if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<portal_skript_1>().GetDestination().position;
            }
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleport = collision.gameObject;  
        }    
    
    
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if(collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        
        
        }       
    }





}
