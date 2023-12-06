using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private float hp;

    public Vector2 moveVector; // Вектор, возвращающий изменения персонажа по оси x и y для передачи в Rigidbody и изменения положения игрока.
    public float speed = 2f; // Переменная, отвечающая за скорость передвижения персонажа.
    public float jumpForce = 7f; // Переменная, отвечающая за силу с которой персонаж отталкивается от земли. Фиксированное значение пикселей вверх.
    public bool djump = false;
    public bool dj = true;

    public bool onGround; // Проверка на касание земли.
    public LayerMask Ground; // Функциональный слой, от которого отталкивается персонаж.
    [Range(-5f, 5f)] public float CheckGroundOffsetY = 0f; // Переменная смещения коллайдера по y.
    [Range(0, 5f)] public float CheckGroundRadius = 0.1f; // Переменная радиуса коллайдера.
    public Rigidbody2D rb; // Создание компонента.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Получение компонента Rigidbody для дальнейщего взаимодеиствия через него с физикой (движение персонажа).
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius, Ground); // Проверка входит ли в созданный коллайдер, коллайдер с функциональным слоем Земля.

        if (Input.GetKeyDown(KeyCode.Space) && onGround) // Проверка, может ли персонаж прыгать.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Задание скорости движения по y.
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("comb")) {
            djump = true;
        }
    }
}
