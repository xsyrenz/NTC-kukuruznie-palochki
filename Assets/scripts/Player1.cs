using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 15f;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Vector2 moveVector;
    public LayerMask Ground;
    public LayerMask Mec;
    public LayerMask Honey;
    public bool onGround;
    private Transform tf;
    [Range(-10f, 5f)] public float CheckGroundOffsetY = 0f; // ���������� �������� ���������� �� y.
    [Range(0, 5f)] public float CheckGroundRadius = 0.1f;
    public float xpos;
    [Range(-10f, 5f)] public float isslowedOffsetY = 0f; // ���������� �������� ���������� �� y.
    [Range(0, 5f)] public float isslowedRadius = 0.1f;
    public bool isslowed;
    private Animator anim;
    public enum States
    {
        idle,
        run

    }

    private States State
    {
        get { return (States)anim.GetInteger("state"); }
        set { anim.SetInteger("State", (int)value); }
    }


    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite= GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onGround) State = States.idle;

        xpos = tf.position.x;
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            State = States.run;
            sprite.flipX = Input.GetAxisRaw("Horizontal") < 0.0f;
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            State = States.run;
            sprite.flipX = Input.GetAxisRaw("Horizontal") < 0.0f;
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
        onGround = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + CheckGroundOffsetY), CheckGroundRadius, Ground); // �������� ������ �� � ��������� ���������, ��������� � �������������� ����� �����.
        isslowed = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + isslowedOffsetY), isslowedRadius, Honey);
        if (Input.GetKeyDown(KeyCode.Space) && onGround) // ��������, ����� �� �������� �������.
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // ������� �������� �������� �� y.
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider2D[] mecs = Physics2D.OverlapCircleAll(tf.position, 1, Mec);
            foreach (Collider2D Lever in mecs)
            {
                Lever.GetComponent<Mechnizm>().Action();
            }
        }
        if (isslowed)
        {
            speed = 0.5f;
            jumpForce= 5;
            Heartsystem.health += 1;
        }
        else
        {
            speed = 3f;
            jumpForce = 7f;
        }
        
    }
}
