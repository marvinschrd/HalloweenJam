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
    Animator anim;
    float horizontalSpeed;
    bool facingRight = true;
    bool facingLeft = false;

    Vector2 mousePosition;

    Camera cam;

    [SerializeField] float dashSpeed = 0;

    bool dashing = false;

    Vector3 dashDirection;

    [SerializeField] float dashTimer = 1.0f;
    float dashTime;
    TrailRenderer dashTrail;

    ScreenShaker screenshake;


    bool isGrounded = true;
    [SerializeField]Transform feetPosition;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float checkRadius;
    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
            body = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            cam = FindObjectOfType<Camera>();
            dashTrail = GetComponent<TrailRenderer>();
            screenshake = FindObjectOfType<ScreenShaker>();
        
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


        switch(state)
        {
            case State.IDLE:
                dashTrail.emitting = false;
                direction = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
                if (isGrounded && Input.GetKeyDown("space"))
                {
                   body.velocity = Vector2.up * jumpForce;
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
                dashTrail.emitting = true;
                screenshake.TriggerShake(0.1f);
                dashTime -= Time.deltaTime;
                //  transform.position = Vector3.Lerp(transform.position, dashDirection, Time.deltaTime* dashSpeed);
                //body.velocity = Vector3.Lerp(transform.position, dashDirection, Time.deltaTime * dashSpeed);
                body.velocity = (dashDirection - transform.position).normalized * dashSpeed;
                if (dashTime<=0)
                {
                    transform.position = transform.position;
                    body.velocity = new Vector2(1f, 1f);
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



        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("dash");
            state = State.SELECTDASHPOSITION;
        }
        if(Input.GetMouseButtonUp(0))
        {
            dashing = false;
        }


        // anim.SetFloat("speed", Mathf.Abs(horizontalSpeed));
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       

    }

    

}
