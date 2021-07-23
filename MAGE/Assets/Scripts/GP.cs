using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GP : MonoBehaviour
{
    public float speed = 1.5f; // Скорость червяка
    public bool moveLeft = true; // Переменная, отвечающая за направление движения
    public Transform groundDetect; // Наш детектор

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // Перемещение врага влево
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 1f); // Получение информации о объекте столкновение с лучом
        if (groundInfo.collider == false) // Проверяем закончилась ли плантформа
        {
            if (moveLeft == true) // Если двигаюсь в лево то поварачиваюсь направо
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                moveLeft = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
            }
        }
    }
}