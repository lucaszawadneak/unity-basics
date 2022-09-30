using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update

  private int life = 3;
  private bool isGettingHit = false;
  private Rigidbody2D body;

  public GameObject player;
  public float speed;

  private float distance;
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (life <= 0)
    {
      Destroy(gameObject);
    }
    if (isGettingHit)
    {
      GetComponent<SpriteRenderer>().color = Color.red;
      life--;
      isGettingHit = false;
    }

    distance = Vector2.Distance(transform.position, player.transform.position);
    Vector2 direction = player.transform.position - transform.position;
    direction.Normalize();


    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);


    if (direction.x <= 0.01f)
    {
      float newDirection = Mathf.Abs(transform.localScale.x);
      transform.localScale = new Vector2(newDirection, transform.localScale.y);
    }
    else
    {
      float newDirection = -Mathf.Abs(transform.localScale.x);
      transform.localScale = new Vector2(newDirection, transform.localScale.y);
    }


  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.tag == "Player")
    {
      collision.GetComponentInChildren<LifeSystem>().TakeDamage();
    }
    else if (collision.tag == "PlayerAttack")
    {
      Debug.Log("Enemy hit " + life);
      isGettingHit = true;
      body.AddForce(new Vector2(10f, 10f), ForceMode2D.Impulse);
    }

  }

  private void OnTriggerExit2D(Collider2D other)
  {
    if (other.tag == "PlayerAttack")
    {
      isGettingHit = false;
      GetComponent<SpriteRenderer>().color = Color.white;
    }
  }




}
