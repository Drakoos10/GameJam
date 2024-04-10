using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [Header("Movimiento")]
    public float velocidad = 5f;
    private float horizontal;
    private bool mirandoDerecha = true;
    public Animator animator;


    [Header("Salto")]
    public float speedSalto = 8f;
    public Transform checkPiso;
    public LayerMask layerPiso;


    [Header("Dash")]
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {

            return;
        }
        
        horizontal=Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontal*velocidad,rb.velocity.y);
        if(horizontal!=0){
            //animator.SetBool("Move", true);
        }else if(horizontal==0){
            //animator.SetBool("Move", false);
        }
           


       if (Input.GetButtonDown("Jump") && isGrounded())
        {
            //animator.SetBool("Salto", true);
            rb.velocity = new Vector2(rb.velocity.x, speedSalto);

        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (isGrounded() && rb.velocity.y <= 0) 
        {
            //animator.SetBool("Salto", false);   
        }

         voltear();

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash) 
        {
            StartCoroutine(Dash());
        }
    }
     private void voltear()
    {
        if(mirandoDerecha && horizontal<0f || !mirandoDerecha && horizontal> 0f)
        {
            mirandoDerecha = !mirandoDerecha;
            transform.Rotate(0f,180f,0f);
            
        }
    }
     private bool isGrounded()
    {
        return Physics2D.OverlapCircle(checkPiso.position, 0.2f, layerPiso);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Determinar la direcci�n del dash bas�ndose en la orientaci�n actual del jugador
        float dashDirection = mirandoDerecha ? 1f : -1f; // Si mirandoDerecha es verdadero, dash hacia la derecha, de lo contrario, dash hacia la izquierda

        // Aplicar una velocidad constante en la direcci�n adecuada para el dashSSSS
        rb.velocity = new Vector2(dashDirection * dashingPower, 0f);

        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;

        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}

