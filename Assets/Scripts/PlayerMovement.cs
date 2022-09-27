using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

  private Rigidbody2D body;
  [SerializeField] private float speed;

  private void Awake()
  {
    body = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    float horizontal = Input.GetAxis("Horizontal");
    body.velocity = new Vector2(horizontal * speed, body.velocity.y);

    if (horizontal > 0.01f)
    {
      transform.localScale = new Vector3(1, 1, 1);
    }
    else if (horizontal < -0.01f)
    {
      transform.localScale = new Vector3(-1, 1, 1);
    }


    if (Input.GetKey(KeyCode.Space))
    {
      body.velocity = new Vector2(body.velocity.x, 5f);
    }

  }
}
