using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  // Start is called before the first frame update

  private int life = 4;
  private bool isGettingHit = false;
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
