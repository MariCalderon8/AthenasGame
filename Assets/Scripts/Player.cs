using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables de movimiento
    public float moveSpeed = 10f;
    public float jumpForce = 50f;
    
    // Detección de suelo
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool wasGrounded;

    // Parámetros del Animator
    private readonly string paramMovimiento = "Movimiento";
    private readonly string paramSaltando = "Saltando";
    private readonly string paramCayendo = "Cayendo";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Almacena el estado anterior para detectar cambios
        wasGrounded = isGrounded;
        // Actualiza el estado del suelo usando Physics2D.OverlapCircle
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        
        Move();
        Jump();
        UpdateAnimations();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat(paramMovimiento, Mathf.Abs(moveInput));
        
        // Mirar en la dirección del movimiento
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void Jump()
    {
        if (isGrounded && (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W)))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            // Activar animación de salto inmediatamente
            animator.SetBool(paramSaltando, true);
            animator.SetBool(paramCayendo, false);
        }
    }
    
    void UpdateAnimations()
    {
        // Si acaba de tocar el suelo, desactivar animaciones de salto/caída
        if (isGrounded && !wasGrounded)
        {
            animator.SetBool(paramSaltando, false);
            animator.SetBool(paramCayendo, false);
        }
        // Si está en el aire
        else if (!isGrounded)
        {
            // Subiendo (velocidad vertical positiva) -> animación de salto
            if (rb.linearVelocity.y > 0.1f)
            {
                animator.SetBool(paramSaltando, true);
                animator.SetBool(paramCayendo, false);
            }
            // Cayendo (velocidad vertical negativa) -> animación de caída
            else if (rb.linearVelocity.y < -0.1f)
            {
                animator.SetBool(paramSaltando, false);
                animator.SetBool(paramCayendo, true);
            }
        }
    }
    
    // // Visualización del groundCheck en el editor
    // void OnDrawGizmosSelected()
    // {
    //     if (groundCheck == null) return;
        
    //     Gizmos.color = Color.yellow;
    //     Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    // }
}