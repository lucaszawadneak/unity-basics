using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D body;
  [SerializeField] private float speed;
  [SerializeField] private float jumpForce;

  private Animator animator;



  private bool isJumping = false;

  private float delayToIdle = 0.0f;

  private bool IsGrounded()
  {
    return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
  }


  private void Awake()
  {
    body = GetComponent<Rigidbody2D>();
  }

  private void Start()
  {
    animator = GetComponent<Animator>();
  }

  private void Update()
  {

    float horizontal = Input.GetAxis("Horizontal");
    body.velocity = new Vector2(horizontal * speed, body.velocity.y);

    if (horizontal > 0.01f)
    {
      float newDirection = Mathf.Abs(transform.localScale.x);
      transform.localScale = new Vector2(newDirection, transform.localScale.y);
    }
    else if (horizontal < -0.01f)
    {
      float newDirection = -Mathf.Abs(transform.localScale.x);
      transform.localScale = new Vector2(newDirection, transform.localScale.y);
    }

    if (IsGrounded())
    {
      animator.SetBool("Grounded", true);
      if (isJumping)
      {
        isJumping = false;
      }
    }

    if (Mathf.Abs(horizontal) > Mathf.Epsilon)
    {
      // Reset timer
      delayToIdle = 0.03f;
      animator.SetInteger("AnimState", 1);
    }


    if (Input.GetKey(KeyCode.Space) && !isJumping)
    {
      body.velocity = new Vector2(body.velocity.x, jumpForce);
      animator.SetTrigger("Jump");
      animator.SetBool("Grounded", false);
      isJumping = true;
    }
    else
    {
      delayToIdle -= Time.deltaTime;
      if (delayToIdle < 0)
        animator.SetInteger("AnimState", 0);
    }

  }

}
