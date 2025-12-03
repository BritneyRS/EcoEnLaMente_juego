using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;

    Vector2 movement;
    Vector2 targetPoint;
    bool movingToClick = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        targetPoint = rb.position;
    }

    void Update()
    {
        // ---------------------------
        //  MOVIMIENTO CON TECLAS
        // ---------------------------
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement != Vector2.zero)
        {
            movingToClick = false; // si usas teclas, cancelas movimiento por click
            targetPoint = rb.position;
        }

        // ---------------------------
        //  MOVIMIENTO CON CLICK DE MOUSE
        // ---------------------------
        if (Input.GetMouseButtonDown(0)) // click izquierdo
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPoint = mousePos;
            movingToClick = true;
        }

        // ---------------------------
        // ANIMACIÓN
        // ---------------------------
        bool isMoving = (movement != Vector2.zero || movingToClick);
        anim.SetBool("Caminar", isMoving);

        // Girar sprite a izquierda / derecha
        if (movement.x > 0 || (movingToClick && targetPoint.x > rb.position.x))
            sr.flipX = false;
        else if (movement.x < 0 || (movingToClick && targetPoint.x < rb.position.x))
            sr.flipX = true;
    }

    void FixedUpdate()
    {
        // ---------------------------
        //  TECLADO
        // ---------------------------
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            return;
        }

        // ---------------------------
        //  MOUSE CLICK
        // ---------------------------
        if (movingToClick)
        {
            Vector2 newPos = Vector2.MoveTowards(rb.position, targetPoint, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);

            float distance = Vector2.Distance(rb.position, targetPoint);
            if (distance < 0.05f)
                movingToClick = false;
        }
    }
}
