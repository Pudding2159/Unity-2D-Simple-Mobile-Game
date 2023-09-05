using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
     public Transform player; // Должен быть присоединен объект "Player" в редакторе Unity
    public Vector3 teleportPosition;
    public Vector3 teleportPosition1;
    public Vector2 fallVelocity = new Vector2(0f, 0f); // Установите желаемую скорость падения

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("traps"))
        {
            TeleportPlayer();
        }
        if (collision.gameObject.CompareTag("traps2"))
        {
            TeleportPlayer1();
        }
        // if (collision.gameObject.CompareTag("Exit"))
        // {
        //     game_Over.Setup();
        // }
        
    }

    private void TeleportPlayer()
    {
        player.position = teleportPosition;

        // Устанавливаем скорость падения игрока
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = fallVelocity;
        }
        else
        {
            Debug.LogError("Не найден компонент Rigidbody2D на игроке!");
        }
    }


    private void TeleportPlayer1()
    {
        player.position = teleportPosition1;

        // Устанавливаем скорость падения игрока
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        if (playerRigidbody != null)
        {
            playerRigidbody.velocity = fallVelocity;
        }
        else
        {
            Debug.LogError("Не найден компонент Rigidbody2D на игроке!");
        }
    }
    

    private void Update() {
        Debug.Log(player.position + "--- Position");
    }
}
