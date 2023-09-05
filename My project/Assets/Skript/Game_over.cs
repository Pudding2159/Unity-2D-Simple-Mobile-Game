using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Game_over : MonoBehaviour
{
    public GameObject gameOverText; // Ссылка на объект с текстом "Game Over"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Проверяем тег объекта, с которым произошло столкновение
        if (collision.CompareTag("Exit"))
        {
            // Активируем объект с текстом "Game Over"
            gameOverText.SetActive(true);
        }
    }
}