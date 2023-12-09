using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    private float hp;

    public Vector2 moveVector; // ������, ������������ ��������� ��������� �� ��� x � y ��� �������� � Rigidbody � ��������� ��������� ������.
    public float speed = 2f; // ����������, ���������� �� �������� ������������ ���������.
    public float jumpForce = 7f; // ����������, ���������� �� ���� � ������� �������� ������������� �� �����. ������������� �������� �������� �����.
    public bool djump = false;
    public bool dj = true;

    public bool onGround; // �������� �� ������� �����.
    public LayerMask Ground; // �������������� ����, �� �������� ������������� ��������.
    [Range(-5f, 5f)] public float CheckGroundOffsetY = 0f; // ���������� �������� ���������� �� y.
    [Range(0, 5f)] public float CheckGroundRadius = 0.1f; // ���������� ������� ����������.
    public Rigidbody2D rb; // �������� ����������.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ��������� ���������� Rigidbody ��� ����������� �������������� ����� ���� � ������� (�������� ���������).
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

        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius, Ground); // �������� ������ �� � ��������� ���������, ��������� � �������������� ����� �����.

        if (Input.GetKeyDown(KeyCode.Space) && onGround) // ��������, ����� �� �������� �������.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ������� �������� �������� �� y.
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("comb")) {
            djump = true;
        }
    }
}
