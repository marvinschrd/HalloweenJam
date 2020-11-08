using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    Rigidbody2D body;
    Vector2 direction;
    Vector2 Jumping;
    [SerializeField] float jumpForce = 0;
    bool isJumping = false;
    [SerializeField] float speed = 3;
    float horizontalSpeed;
    

    Vector2 mousePosition;

    Camera cam;


    [SerializeField] float dashSpeed = 0;
    bool dashing = false;
    Vector3 dashDirection;
    [SerializeField] float dashTimer = 1.0f;
    float dashTime;
    TrailRenderer dashTrail;
    ScreenShaker screenshake;
    int dashCount;
    [SerializeField] int maxDashCount;


    bool isGrounded = true;
    [SerializeField]Transform feetPosition;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float checkRadius;
    int jumpCount = 0;

    Animator animator;
    SpriteRenderer sprite;
    bool facingRight = true;
    bool facingLeft = false;
    // Start is called before the first frame update
    void Start()
    {
        
            body = GetComponent<Rigidbody2D>();
            cam = FindObjectOfType<Camera>();
            dashTrail = GetComponent<TrailRenderer>();
            screenshake = FindObjectOfType<ScreenShaker>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dashTrail.enabled = false;
    }
    enum State
    {
        IDLE,
        SELECTDASHPOSITION,
        DASH
    }
    State state = State.IDLE;

    private void FixedUpdate()
    {
        if(state != State.DASH)
        {
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
        }
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, checkRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(body.velocity.y);
        animator.SetFloat("fallingSpeed", body.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        if(body.velocity.x<0 && facingRight)
        {
            facingRight = false;
            facingLeft = true;
            animator.transform.Rotate(0, 180, 0);
        }
        if (body.velocity.x >0 && facingLeft)
        {
            facingLeft = false;
            facingRight = true;
            animator.transform.Rotate(0, 180, 0);
            
        }

        switch (state)
        {
            case State.IDLE:
                direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
                horizontalSpeed = Input.GetAxis("Horizontal");
                animator.SetFloat("speed", Mathf.Abs(body.velocity.x));
                if(isGrounded)
                {
                    dashCount = 0;
                }
                if (isGrounded && Input.GetKeyDown("w"))
                {
                   body.velocity = Vector2.up * jumpForce;
                    animator.SetTrigger("isJumping");
                }
                break;
            case State.SELECTDASHPOSITION:
                dashDirection = mousePosition;
                Debug.Log(dashDirection);
                dashing = true;
                dashTime = dashTimer;
                state = State.DASH;
                break;
            case State.DASH:
                dashTrail.enabled = true;
                screenshake.TriggerShake(0.1f);
                //animator.SetBool("isDashing", true);
                animator.SetTrigger("dashing");
                dashTime -= Time.deltaTime;
                body.velocity = (dashDirection - transform.position).normalized * dashSpeed;
                if (dashTime<=0)
                {
                    transform.position = transform.position;
                    dashTrail.enabled = false;
                    body.velocity = new Vector2(body.velocity.x, 0f);
                    state = State.IDLE;
                }
                //if(Input.GetKeyDown("d"))
                // {
                //     // body.velocity = (new Vector3(transform.position.x + rightDash, transform.position.y)  - transform.position).normalized * dashSpeed;
                //     Debug.Log("dashing");
                //     //transform.position += new Vector3(dashSpeed * Time.deltaTime, 0.1f, 0.0f);

                // }
                //if (transform.position.x - dashDirection.x <= 0.1f)
                //{
                //    state = State.IDLE;
                //}
                break;
        }    



        if (Input.GetMouseButtonDown(1)&&dashCount<maxDashCount)
        {
            Debug.Log("dash");
            dashCount++;
            state = State.SELECTDASHPOSITION;
        }
        if(Input.GetMouseButtonUp(1))
        {
            dashing = false;
        }


        // anim.SetFloat("speed", Mathf.Abs(horizontalSpeed));
    }


    public void EndDashAnim()
    {
        animator.SetBool("isDashing", false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       

    }

    

}
