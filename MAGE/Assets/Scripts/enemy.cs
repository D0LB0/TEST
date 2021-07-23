using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isHit = false; // Вспомогательная переменная, отвечающая за возможность нанесения урона Майку
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !isHit)
        {
            collision.gameObject.GetComponent<PlayerDemid>().RecountHp(-1);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 10f, ForceMode2D.Impulse);

        }
    }

    // Метод, который вызывает корутину Death
    public void StartDeath()
    {
        StartCoroutine(Death());
    }

    // Корутина, отвечающая за воспроизведение анимации смерти, падения вниз и уничтожения врага
    IEnumerator Death()
    {
        isHit = true;
        GetComponent<Animator>().SetBool("Dead", true); // Включаем анимацию смерти

        // Именяем тип объекта с кинематического на динамический. Теперь на объект действует сила тяжести
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        // Выключаем коллайдер врага и первого дочернего объекта
        GetComponent<Collider2D>().enabled = false;
        transform.GetChild(0).GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(2f); // Ждём 2 секунды
        Destroy(gameObject); // Полностью уничтожаем врага. Удаляем его из игры

    }
}
